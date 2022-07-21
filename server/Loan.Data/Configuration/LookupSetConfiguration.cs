using Loan.Entity;
using Loan.Interface.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Loan.Data.Configuration
{
    public class LookupSetConfiguration : IEntityTypeConfiguration<LookupSet>
    {
        public void Configure(EntityTypeBuilder<LookupSet> builder)
        {            
            builder.HasData(GetLookupSets());
        }

        public IEnumerable<LookupSet> GetLookupSets()
        {
            return new List<LookupSet> {
             new LookupSet {
                    Id = LookupIds.LookupSetId.TransactionTypeSetId,
                    Name = "Transaction Type",
                    Description = "Transaction types",
                    CreateBy = Seed.SEED_USER,
                    CreatedAt = Seed.SeedDate(),
                    TransactionId = Seed.SeedTransactionId(),
                    VersionNo = 0,
                    RecordStatusId = LookupIds.RecordStatus.Active,
                    SeedTypeId = LookupIds.SeedTypes.Constant
                },
                new LookupSet
                {
                    Id = LookupIds.LookupSetId.DurationTypeSetId,
                    Name = "Duration Type",
                    Description = "Duration types",
                    CreateBy = Seed.SEED_USER,
                    CreatedAt = Seed.SeedDate(),
                    TransactionId = Seed.SeedTransactionId(),
                    VersionNo = 0,
                    RecordStatusId = LookupIds.RecordStatus.Active,
                    SeedTypeId = LookupIds.SeedTypes.Constant
                },
                new LookupSet
                {
                    Id = LookupIds.LookupSetId.RepaymentScheduleId,
                    Name = "Repayment Schedule",
                    Description = "Repayment schedules",
                    CreateBy = Seed.SEED_USER,
                    CreatedAt = Seed.SeedDate(),
                    TransactionId = Seed.SeedTransactionId(),
                    VersionNo = 0,
                    RecordStatusId = LookupIds.RecordStatus.Active,
                    SeedTypeId = LookupIds.SeedTypes.Constant
                },
                new LookupSet
                {
                    Id = LookupIds.LookupSetId.RecordStatusSetId,
                    Name = "Record Status",
                    Description = "Record statuses",
                    CreateBy = Seed.SEED_USER,
                    CreatedAt = Seed.SeedDate(),
                    TransactionId = Seed.SeedTransactionId(),
                    VersionNo = 0,
                    RecordStatusId = LookupIds.RecordStatus.Active,
                    SeedTypeId = LookupIds.SeedTypes.Constant
                },
                new LookupSet
                {
                    Id = LookupIds.LookupSetId.SeedTypeSetId,
                    Name = "Seed Constant Type",
                    Description = "Seed constant types",
                    CreateBy = Seed.SEED_USER,
                    CreatedAt = Seed.SeedDate(),
                    TransactionId = Seed.SeedTransactionId(),
                    VersionNo = 0,
                    RecordStatusId = LookupIds.RecordStatus.Active,
                    SeedTypeId = LookupIds.SeedTypes.Constant
                },
                new LookupSet
                {
                    Id = LookupIds.LookupSetId.ChangeOperationSetId,
                    Name = "Change Operations",
                    Description = "Change Operations Create, Update & Delete",
                    CreateBy = Seed.SEED_USER,
                    CreatedAt = Seed.SeedDate(),
                    TransactionId = Seed.SeedTransactionId(),
                    VersionNo = 0,
                    RecordStatusId = LookupIds.RecordStatus.Active,
                    SeedTypeId = LookupIds.SeedTypes.Constant
                },
                new LookupSet
                {
                    Id = LookupIds.LookupSetId.AccountStatusId,
                    Name = "Account Status",
                    Description = "Account statuses i.e. Active, Pending etc",
                    CreateBy = Seed.SEED_USER,
                    CreatedAt = Seed.SeedDate(),
                    TransactionId = Seed.SeedTransactionId(),
                    VersionNo = 0,
                    RecordStatusId = LookupIds.RecordStatus.Active,
                    SeedTypeId = LookupIds.SeedTypes.Constant
                },
                new LookupSet
                {
                    Id = LookupIds.LookupSetId.JournalEntryTypeId,
                    Name = "Journal Entry Type",
                    Description = "Journal Entry Type (Debit/Credit)",
                    CreateBy = Seed.SEED_USER,
                    CreatedAt = Seed.SeedDate(),
                    TransactionId = Seed.SeedTransactionId(),
                    VersionNo = 0,
                    RecordStatusId = LookupIds.RecordStatus.Active,
                    SeedTypeId = LookupIds.SeedTypes.Constant
                },
                new LookupSet
                {
                    Id = LookupIds.LookupSetId.InterestCycleTypeId,
                    Name = "Interest Cycle Type",
                    Description = "Interest Cycle Type",
                    CreateBy = Seed.SEED_USER,
                    CreatedAt = Seed.SeedDate(),
                    TransactionId = Seed.SeedTransactionId(),
                    VersionNo = 0,
                    RecordStatusId = LookupIds.RecordStatus.Active,
                    SeedTypeId = LookupIds.SeedTypes.Constant
                }
            };
        
        }

    }
}
