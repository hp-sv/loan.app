
using Loan.Entity;
using Microsoft.EntityFrameworkCore;

namespace Loan.Data.Configuration
{
    internal static class ClientConfiguration
    {
        public static void ApplyConfiguration(ModelBuilder modelBuilder) {
            // Computed Columns
            modelBuilder.Entity<Client>()
                .Property(p => p.FullName)
                .HasComputedColumnSql("replace(replace([FirstName] + ' ' + [MiddleName] + ' ' + [LastName], '  ',' '), '  ', ' ') PERSISTED");

            modelBuilder.Entity<Client>()
                .Property(p => p.FullAddress)
                .HasComputedColumnSql("replace(replace([AddressLine1] + ' ' + [AddressLine2] + ' ' + [AddressLine3], '  ',' '), '  ', ' ')  PERSISTED");

        }
    }
}
