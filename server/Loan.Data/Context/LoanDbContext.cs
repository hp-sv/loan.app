using Loan.Data.Configuration;
using Loan.Entity;
using Loan.Interface.Constants;
using Loan.Interface.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Loan.Data.Context
{
    public class LoanDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; } = null!;
        public DbSet<Account> Accounts { get; set; } = null!;
        public DbSet<AccountTransaction> AccountTransactions { get; set; } = null!;

        public async Task<int> SaveChangesAsync()
        {
            return await SaveChangesAsync(CancellationToken.None);
        }

        public DbSet<Lookup> Lookups { get; set; } = null!;
        public DbSet<LookupSet> LookupSets { get; set; } = null!;

        public DbSet<ChangeTransaction> ChangeTransactions { get; set; } = null!;
        public DbSet<ChangeEntity> ChangeEntities { get; set; } = null!;
        public DbSet<ChangeEntityDetail> ChangeEntityDetails { get; set; } = null!;

        private readonly IChangeTransactionScope _transactionScope;

        public LoanDbContext(DbContextOptions<LoanDbContext> options, IChangeTransactionScope transactionScope) : base(options)
        {            
            _transactionScope = transactionScope ?? throw new ArgumentNullException(nameof(transactionScope));               
        }        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            // Set to singular table name
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())            
                modelBuilder.Entity(entityType.ClrType).ToTable(entityType.ClrType.Name);

            //Disable cascade on delete
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().Where(e => !e.IsOwned()).SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.ClientCascade;

            // Soft delete query filter 
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())                            
                if (typeof(ILoanEntity).IsAssignableFrom(entityType.ClrType))                
                    entityType.AddActiveRecordOnlyQueryFilter();

            // Computed Columns
            modelBuilder.Entity<Client>()
                .Property(p => p.FullName)
                .HasComputedColumnSql("replace(replace([FirstName] + ' ' + [MiddleName] + ' ' + [LastName], '  ',' '), '  ', ' ') PERSISTED");

            modelBuilder.Entity<Client>()
                .Property(p => p.FullAddress)
                .HasComputedColumnSql("replace(replace([AddressLine1] + ' ' + [AddressLine2] + ' ' + [AddressLine3], '  ',' '), '  ', ' ')  PERSISTED");
                        
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new LookupSetConfiguration());
            modelBuilder.ApplyConfiguration(new LookupConfiguration());

        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            await OnBeforeSaveChangesAsync();
            int result = await base.SaveChangesAsync(cancellationToken);
            await OnAfterSaveChanges();
            return result;
        }

        private readonly List<string> exceptedColumns = new List<string> { "CreatedBy", "CreatedAt", "UpdatedBy", "UpdatedAt", "TransactionId" };


        private async Task OnAfterSaveChanges()
        {
            var entries = ChangeTracker.Entries();
            bool hasAddedEntity = false;

            foreach (var entry in ChangeTracker.Entries())
            {
                if (!(entry.Entity is EntityBase))
                    continue;

                var entity = (EntityBase)entry.Entity;
                if (entity.OriginalPrimaryKeyValue < 0)
                {
                    var primaryKeyProperty = entry.Properties.FirstOrDefault(p => p.Metadata.IsPrimaryKey() && !exceptedColumns.Contains(p.Metadata.Name));
                    if (primaryKeyProperty != null)
                    {
                        string currentValue = $"{(primaryKeyProperty.CurrentValue != null ? primaryKeyProperty.CurrentValue.ToString() : string.Empty)}";
                        int newPrimaryKeyValue;
                        if (int.TryParse(currentValue, out newPrimaryKeyValue))
                        {
                            var changeEntity = ChangeEntities.FirstOrDefault(ce => ce.TransactionId == _transactionScope.TransactionId && ce.PrimaryKey == entity.OriginalPrimaryKeyValue);
                            if (changeEntity != null)
                            {
                                changeEntity.PrimaryKey = newPrimaryKeyValue;
                                hasAddedEntity = true;
                            }
                        }
                    }

                }
            }

            if (hasAddedEntity)
                await base.SaveChangesAsync(CancellationToken.None);
        }
        

        private Task OnBeforeSaveChangesAsync()
        {
            var changeEntities = new List<ChangeEntity>();

            foreach (var entry in ChangeTracker.Entries())
            {                
                if (!(entry.Entity is EntityBase) || entry.State == EntityState.Detached || entry.State == EntityState.Unchanged)
                    continue;

                var changeEntity = new ChangeEntity
                {
                    EntityName = entry.Entity.GetType().Name,
                    TransactionId = _transactionScope.TransactionId
                };

                changeEntities.Add(changeEntity);

                // Set the row transaction column values
                var entity = (EntityBase)entry.Entity;
                entity.TransactionId = _transactionScope.TransactionId;
                switch (entry.State)
                {
                    case EntityState.Added:
                        changeEntity.ChangeOperationId = LookupIds.ChangeOperations.Create;
                        entity.CreatedAt = _transactionScope.TransactionDate;
                        entity.CreateBy = _transactionScope.CurrentUser;
                        entity.RecordStatusId = LookupIds.RecordStatus.Active;
                        entity.VersionNo = 1;
                        break;
                    case EntityState.Modified:
                        changeEntity.ChangeOperationId = LookupIds.ChangeOperations.Update;
                        entity.UpdatedAt = _transactionScope.TransactionDate;
                        entity.UpdatedBy = _transactionScope.CurrentUser;

                        changeEntity.ChangeEntityDetails.Add(
                            new ChangeEntityDetail
                            {
                                ColumnName = "VersionNo",
                                OldValue = entity.VersionNo.ToString(),
                                NewValue = (entity.VersionNo + 1).ToString()
                            });

                        entity.VersionNo = entity.VersionNo + 1;

                        break;
                }
                              

                foreach (var property in entry.Properties.Where(p => !exceptedColumns.Contains(p.Metadata.Name)))
                {  
                    string propertyName = property.Metadata.Name;
                    string currentValue = $"{(property.CurrentValue != null ? property.CurrentValue.ToString() : string.Empty)}";
                    string originalValue = $"{(property.OriginalValue != null ? property.OriginalValue.ToString() : string.Empty)}";

                    if (property.Metadata.IsPrimaryKey())
                    {
                        int primaryKeyValue;
                        if(int.TryParse(currentValue, out primaryKeyValue))
                        {
                            changeEntity.PrimaryKey = primaryKeyValue;
                            entity.OriginalPrimaryKeyValue = primaryKeyValue;
                        }
                        continue;
                    }

                    switch (entry.State)
                    {
                        case EntityState.Added:
                            changeEntity.ChangeEntityDetails.Add(
                                new ChangeEntityDetail
                                {
                                    ColumnName = propertyName,
                                    NewValue = currentValue
                                });                            
                            break;                        
                        case EntityState.Modified:
                            if (property.IsModified)
                            {                                
                                changeEntity.ChangeEntityDetails.Add(
                                new ChangeEntityDetail
                                {
                                    ColumnName = propertyName,
                                    OldValue = originalValue,
                                    NewValue = currentValue 
                                });
                            }
                            break;
                    }
                }                
            }

            var changeTransaction = new ChangeTransaction
            {
                ChangeEntities = changeEntities,
                TransactionId = _transactionScope.TransactionId,
                CreatedAt = _transactionScope.TransactionDate,
                CreatedBy = _transactionScope.CurrentUser,
                TransactionPath = _transactionScope.TransactionPath

            };
            ChangeTransactions.Add(changeTransaction);

            return Task.CompletedTask;
        }
    }
}
