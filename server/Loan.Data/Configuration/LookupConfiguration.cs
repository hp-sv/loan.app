using Loan.Entity;
using Loan.Interface.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Loan.Data.Configuration
{
    public class LookupConfiguration : IEntityTypeConfiguration<Lookup>
    {
        public void Configure(EntityTypeBuilder<Lookup> builder)
        {
            builder.HasData(GetTransactionTypes());
            builder.HasData(GetDurationTypes());
            builder.HasData(GetRepaymentSchedule());
            builder.HasData(GetRecordStatus());
            builder.HasData(GetSeedConstants());
            builder.HasData(GetChangeOperations());
            builder.HasData(GetAccountStatuses());
        }

        public IEnumerable<Lookup> GetSeedConstants()
        {
            return new List<Lookup>{
                 new Lookup
                 {
                     Id = LookupIds.SeedTypes.Constant,
                     Name = "Constant",
                     Description = "Constant seed data",
                     LookupSetId = LookupIds.LookupSetId.SeedTypeSetId,
                     CreateBy = Seed.SEED_USER,
                     CreatedAt = Seed.SeedDate(),
                     TransactionId = Seed.SeedTransactionId(),
                     VersionNo = 0,
                     RecordStatusId = LookupIds.RecordStatus.Active,
                     SeedTypeId = LookupIds.SeedTypes.Constant
                 },
                 new Lookup
                 {
                     Id = LookupIds.SeedTypes.UserUpdated,
                     Name = "User Updated",
                     Description = "User updated seed data",
                     LookupSetId = LookupIds.LookupSetId.SeedTypeSetId,
                     CreateBy = Seed.SEED_USER,
                     CreatedAt = Seed.SeedDate(),
                     TransactionId = Seed.SeedTransactionId(),
                     VersionNo = 0,
                     RecordStatusId = LookupIds.RecordStatus.Active,
                     SeedTypeId = LookupIds.SeedTypes.Constant
                 },
                 new Lookup
                 {
                     Id = LookupIds.SeedTypes.Updatable,
                     Name = "Updatable",
                     Description = "Updatable seed data",
                     LookupSetId = LookupIds.LookupSetId.SeedTypeSetId,
                     CreateBy = Seed.SEED_USER,
                     CreatedAt = Seed.SeedDate(),
                     TransactionId = Seed.SeedTransactionId(),
                     VersionNo = 0,
                     RecordStatusId = LookupIds.RecordStatus.Active,
                     SeedTypeId = LookupIds.SeedTypes.Constant
                 } };
        }
        public IEnumerable<Lookup> GetRecordStatus()
        {
            return new List<Lookup> {
                  new Lookup
                  {
                      Id = LookupIds.RecordStatus.Active,
                      Name = "Active",
                      Description = "Active record",
                      LookupSetId = LookupIds.LookupSetId.RecordStatusSetId,
                      CreateBy = Seed.SEED_USER,
                      CreatedAt = Seed.SeedDate(),
                      TransactionId = Seed.SeedTransactionId(),
                      VersionNo = 0,
                      RecordStatusId = LookupIds.RecordStatus.Active,
                      SeedTypeId = LookupIds.SeedTypes.Constant
                  },
                  new Lookup
                  {
                      Id = LookupIds.RecordStatus.Deleted,
                      Name = "Deleted",
                      Description = "Deleted record",
                      LookupSetId = LookupIds.LookupSetId.RecordStatusSetId,
                      CreateBy = Seed.SEED_USER,
                      CreatedAt = Seed.SeedDate(),
                      TransactionId = Seed.SeedTransactionId(),
                      VersionNo = 0,
                      RecordStatusId = LookupIds.RecordStatus.Active,
                      SeedTypeId = LookupIds.SeedTypes.Constant
                  },
                  new Lookup
                  {
                      Id = LookupIds.RecordStatus.Pending,
                      Name = "Pending",
                      Description = "Pending record",
                      LookupSetId = LookupIds.LookupSetId.RecordStatusSetId,
                      CreateBy = Seed.SEED_USER,
                      CreatedAt = Seed.SeedDate(),
                      TransactionId = Seed.SeedTransactionId(),
                      VersionNo = 0,
                      RecordStatusId = LookupIds.RecordStatus.Active,
                      SeedTypeId = LookupIds.SeedTypes.Constant
                  },
                  new Lookup
                  {
                      Id = LookupIds.RecordStatus.Archive,
                      Name = "Archive",
                      Description = "Archive record",
                      LookupSetId = LookupIds.LookupSetId.RecordStatusSetId,
                      CreateBy = Seed.SEED_USER,
                      CreatedAt = Seed.SeedDate(),
                      TransactionId = Seed.SeedTransactionId(),
                      VersionNo = 0,
                      RecordStatusId = LookupIds.RecordStatus.Active,
                      SeedTypeId = LookupIds.SeedTypes.Constant
                  } };
        }
        public IEnumerable<Lookup> GetRepaymentSchedule()
        {
            return new List<Lookup> {
                 new Lookup
                 {
                     Id = LookupIds.RepaymentSchedule.Daily,
                     Name = "Daily",
                     Description = "Daily repayment schedule",
                     LookupSetId = LookupIds.LookupSetId.RepaymentScheduleId,
                     CreateBy = Seed.SEED_USER,
                     CreatedAt = Seed.SeedDate(),
                     TransactionId = Seed.SeedTransactionId(),
                     VersionNo = 0,
                     RecordStatusId = LookupIds.RecordStatus.Active,
                     SeedTypeId = LookupIds.SeedTypes.Constant
                 },
                 new Lookup
                 {
                     Id = LookupIds.RepaymentSchedule.Weekly,
                     Name = "Weekly",
                     Description = "Weekly repayment schedule",
                     LookupSetId = LookupIds.LookupSetId.RepaymentScheduleId,
                     CreateBy = Seed.SEED_USER,
                     CreatedAt = Seed.SeedDate(),
                     TransactionId = Seed.SeedTransactionId(),
                     VersionNo = 0,
                     RecordStatusId = LookupIds.RecordStatus.Active,
                     SeedTypeId = LookupIds.SeedTypes.Constant
                 },
                 new Lookup
                 {
                     Id = LookupIds.RepaymentSchedule.Monthly,
                     Name = "Monthly",
                     Description = "Monthly repayment schedule",
                     LookupSetId = LookupIds.LookupSetId.RepaymentScheduleId,
                     CreateBy = Seed.SEED_USER,
                     CreatedAt = Seed.SeedDate(),
                     TransactionId = Seed.SeedTransactionId(),
                     VersionNo = 0,
                     RecordStatusId = LookupIds.RecordStatus.Active,
                     SeedTypeId = LookupIds.SeedTypes.Constant
                 },
                 new Lookup
                 {
                     Id = LookupIds.RepaymentSchedule.TwiceMonthly,
                     Name = "Twice Monthly",
                     Description = "Twice a month repayment schedule",
                     LookupSetId = LookupIds.LookupSetId.RepaymentScheduleId,
                     CreateBy = Seed.SEED_USER,
                     CreatedAt = Seed.SeedDate(),
                     TransactionId = Seed.SeedTransactionId(),
                     VersionNo = 0,
                     RecordStatusId = LookupIds.RecordStatus.Active,
                     SeedTypeId = LookupIds.SeedTypes.Constant
                 }};
        }
        public IEnumerable<Lookup> GetDurationTypes()
        {
            return new List<Lookup> {
                  new Lookup
                  {
                      Id = LookupIds.DurationType.Week,
                      Name = "Week",
                      Description = "Week duration",
                      LookupSetId = LookupIds.LookupSetId.DurationTypeSetId,
                      CreateBy = Seed.SEED_USER,
                      CreatedAt = Seed.SeedDate(),
                      TransactionId = Seed.SeedTransactionId(),
                      VersionNo = 0,
                      RecordStatusId = LookupIds.RecordStatus.Active,
                      SeedTypeId = LookupIds.SeedTypes.Constant
                  },
                  new Lookup
                  {
                      Id = LookupIds.DurationType.Month,
                      Name = "Month",
                      Description = "Month duration",
                      LookupSetId = LookupIds.LookupSetId.DurationTypeSetId,
                      CreateBy = Seed.SEED_USER,
                      CreatedAt = Seed.SeedDate(),
                      TransactionId = Seed.SeedTransactionId(),
                      VersionNo = 0,
                      RecordStatusId = LookupIds.RecordStatus.Active,
                      SeedTypeId = LookupIds.SeedTypes.Constant
                  },
                  new Lookup
                  {
                      Id = LookupIds.DurationType.Quarter,
                      Name = "Quarter",
                      Description = "Quarter duration",
                      LookupSetId = LookupIds.LookupSetId.DurationTypeSetId,
                      CreateBy = Seed.SEED_USER,
                      CreatedAt = Seed.SeedDate(),
                      TransactionId = Seed.SeedTransactionId(),
                      VersionNo = 0,
                      RecordStatusId = LookupIds.RecordStatus.Active,
                      SeedTypeId = LookupIds.SeedTypes.Constant
                  },
                  new Lookup
                  {
                      Id = LookupIds.DurationType.HalfYear,
                      Name = "Half Year",
                      Description = "Half year duration",
                      LookupSetId = LookupIds.LookupSetId.DurationTypeSetId,
                      CreateBy = Seed.SEED_USER,
                      CreatedAt = Seed.SeedDate(),
                      TransactionId = Seed.SeedTransactionId(),
                      VersionNo = 0,
                      RecordStatusId = LookupIds.RecordStatus.Active,
                      SeedTypeId = LookupIds.SeedTypes.Constant
                  },
                  new Lookup
                  {
                      Id = LookupIds.DurationType.Year,
                      Name = "Year",
                      Description = "Yearly duration",
                      LookupSetId = LookupIds.LookupSetId.DurationTypeSetId,
                      CreateBy = Seed.SEED_USER,
                      CreatedAt = Seed.SeedDate(),
                      TransactionId = Seed.SeedTransactionId(),
                      VersionNo = 0,
                      RecordStatusId = LookupIds.RecordStatus.Active,
                      SeedTypeId = LookupIds.SeedTypes.Constant
                  } };
        }
        public IEnumerable<Lookup> GetTransactionTypes()
            {
            return new List<Lookup> {
                 new Lookup
                 {
                     Id = LookupIds.TransactionType.Credit,
                     Name = "Credit",
                     Description = "Credit transaction",
                     LookupSetId = LookupIds.LookupSetId.TransactionTypeSetId,
                     CreateBy = Seed.SEED_USER,
                     CreatedAt = Seed.SeedDate(),
                     TransactionId = Seed.SeedTransactionId(),
                     VersionNo = 0,
                     RecordStatusId = LookupIds.RecordStatus.Active,
                     SeedTypeId = LookupIds.SeedTypes.Constant
                 },
                 new Lookup
                 {
                     Id = LookupIds.TransactionType.Debit,
                     Name = "Debit",
                     Description = "Debit transaction",
                     LookupSetId = LookupIds.LookupSetId.TransactionTypeSetId,
                     CreateBy = Seed.SEED_USER,
                     CreatedAt = Seed.SeedDate(),
                     TransactionId = Seed.SeedTransactionId(),
                     VersionNo = 0,
                     RecordStatusId = LookupIds.RecordStatus.Active,
                     SeedTypeId = LookupIds.SeedTypes.Constant
                 },
                 new Lookup
                 {
                     Id = LookupIds.TransactionType.Adjustment,
                     Name = "Adjustment",
                     Description = "Adjustment transaction",
                     LookupSetId = LookupIds.LookupSetId.TransactionTypeSetId,
                     CreateBy = Seed.SEED_USER,
                     CreatedAt = Seed.SeedDate(),
                     TransactionId = Seed.SeedTransactionId(),
                     VersionNo = 0,
                     RecordStatusId = LookupIds.RecordStatus.Active,
                     SeedTypeId = LookupIds.SeedTypes.Constant
                 },
                 new Lookup
                 {
                     Id = LookupIds.TransactionType.Interest,
                     Name = "Interest",
                     Description = "Interest transaction",
                     LookupSetId = LookupIds.LookupSetId.TransactionTypeSetId,
                     CreateBy = Seed.SEED_USER,
                     CreatedAt = Seed.SeedDate(),
                     TransactionId = Seed.SeedTransactionId(),
                     VersionNo = 0,
                     RecordStatusId = LookupIds.RecordStatus.Active,
                     SeedTypeId = LookupIds.SeedTypes.Constant
                 }};                
            }
        public IEnumerable<Lookup> GetChangeOperations()
        {
            return new List<Lookup> {
             new Lookup
             {
                 Id = LookupIds.ChangeOperations.Create,
                 Name = "Create",
                 Description = "Create entity",
                 LookupSetId = LookupIds.LookupSetId.TransactionTypeSetId,
                 CreateBy = Seed.SEED_USER,
                 CreatedAt = Seed.SeedDate(),
                 TransactionId = Seed.SeedTransactionId(),
                 VersionNo = 0,
                 RecordStatusId = LookupIds.RecordStatus.Active,
                 SeedTypeId = LookupIds.SeedTypes.Constant
             },
             new Lookup
             {
                 Id = LookupIds.ChangeOperations.Update,
                 Name = "Update",
                 Description = "Update entity",
                 LookupSetId = LookupIds.LookupSetId.TransactionTypeSetId,
                 CreateBy = Seed.SEED_USER,
                 CreatedAt = Seed.SeedDate(),
                 TransactionId = Seed.SeedTransactionId(),
                 VersionNo = 0,
                 RecordStatusId = LookupIds.RecordStatus.Active,
                 SeedTypeId = LookupIds.SeedTypes.Constant
             },
             new Lookup
             {
                 Id = LookupIds.ChangeOperations.Delete,
                 Name = "Delete",
                 Description = "Delete entity",
                 LookupSetId = LookupIds.LookupSetId.TransactionTypeSetId,
                 CreateBy = Seed.SEED_USER,
                 CreatedAt = Seed.SeedDate(),
                 TransactionId = Seed.SeedTransactionId(),
                 VersionNo = 0,
                 RecordStatusId = LookupIds.RecordStatus.Active,
                 SeedTypeId = LookupIds.SeedTypes.Constant
             }};
        }
        public IEnumerable<Lookup> GetAccountStatuses()
        {
            return new List<Lookup> {
             new Lookup
             {
                 Id = LookupIds.AccountStatuses.Pending,
                 Name = "Pending",
                 Description = "Account is pending and waiting for approval",
                 LookupSetId = LookupIds.LookupSetId.AccountStatusId,
                 CreateBy = Seed.SEED_USER,
                 CreatedAt = Seed.SeedDate(),
                 TransactionId = Seed.SeedTransactionId(),
                 VersionNo = 0,
                 RecordStatusId = LookupIds.RecordStatus.Active,
                 SeedTypeId = LookupIds.SeedTypes.Constant
             },
             new Lookup
             {
                 Id = LookupIds.AccountStatuses.Approved,
                 Name = "Approved",
                 Description = "Account is approved",
                 LookupSetId = LookupIds.LookupSetId.AccountStatusId,
                 CreateBy = Seed.SEED_USER,
                 CreatedAt = Seed.SeedDate(),
                 TransactionId = Seed.SeedTransactionId(),
                 VersionNo = 0,
                 RecordStatusId = LookupIds.RecordStatus.Active,
                 SeedTypeId = LookupIds.SeedTypes.Constant
             },
             new Lookup
             {
                 Id = LookupIds.AccountStatuses.Active,
                 Name = "Active",
                 Description = "Account is on going",
                 LookupSetId = LookupIds.LookupSetId.AccountStatusId,
                 CreateBy = Seed.SEED_USER,
                 CreatedAt = Seed.SeedDate(),
                 TransactionId = Seed.SeedTransactionId(),
                 VersionNo = 0,
                 RecordStatusId = LookupIds.RecordStatus.Active,
                 SeedTypeId = LookupIds.SeedTypes.Constant
             },
             new Lookup
             {
                 Id = LookupIds.AccountStatuses.Declined,
                 Name = "Declined",
                 Description = "Account is declined and waiting for approval",
                 LookupSetId = LookupIds.LookupSetId.AccountStatusId,
                 CreateBy = Seed.SEED_USER,
                 CreatedAt = Seed.SeedDate(),
                 TransactionId = Seed.SeedTransactionId(),
                 VersionNo = 0,
                 RecordStatusId = LookupIds.RecordStatus.Active,
                 SeedTypeId = LookupIds.SeedTypes.Constant
             },
             new Lookup
             {
                 Id = LookupIds.AccountStatuses.Cancelled,
                 Name = "Cancelled",
                 Description = "Account is cancelled",
                 LookupSetId = LookupIds.LookupSetId.AccountStatusId,
                 CreateBy = Seed.SEED_USER,
                 CreatedAt = Seed.SeedDate(),
                 TransactionId = Seed.SeedTransactionId(),
                 VersionNo = 0,
                 RecordStatusId = LookupIds.RecordStatus.Active,
                 SeedTypeId = LookupIds.SeedTypes.Constant
             }};
        }
    }
}
