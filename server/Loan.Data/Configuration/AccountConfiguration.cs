using Loan.Entity;
using Loan.Interface.Constants;
using Microsoft.EntityFrameworkCore;

namespace Loan.Data.Configuration
{
    internal static class AccountConfiguration
    {
        internal static void ApplyConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(p => p.Interest)
                .HasComputedColumnSql("(Principal * (Rate/100)) PERSISTED");

            modelBuilder.Entity<Account>()
                .Property(p => p.TotalAmount)
                .HasComputedColumnSql("(Principal * (1+(Rate/100))) PERSISTED");

            modelBuilder.Entity<Account>()
                .Property(p => p.StatusId)
                .HasDefaultValue(LookupIds.AccountStatuses.Pending);

            modelBuilder.Entity<Account>()
                .Property(p => p.DurationTypeId)
                .HasDefaultValue(LookupIds.DurationType.Month);

            modelBuilder.Entity<Account>()
                .Property(p => p.RepaymentTypeId)
                .HasDefaultValue(LookupIds.RepaymentSchedule.Weekly);

            modelBuilder.Entity<Account>()
                .Property(p => p.InterestCycleTypeId)
                .HasDefaultValue(LookupIds.InterestCycleType.Monthly);

            modelBuilder.Entity<AccountTransaction>()
                .Property(p => p.JournalEntryTypeId)
                .HasDefaultValue(LookupIds.JournalEntryType.Debit);

            modelBuilder.Entity<AccountTransaction>()
                .Property(p => p.TransactionTypeId)
                .HasDefaultValue(LookupIds.TransactionType.Projection);
        }
    }
}
