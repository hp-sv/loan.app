
using Loan.Data.Context;
using Loan.Interface.Services;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Loan.Domain.Services
{
    public class ChangeTransactionService : IChangeTransactionService
    {
        private readonly LoanDbContext _context;
        private readonly IChangeTransactionScope _scope;
        public ChangeTransactionService(LoanDbContext context, IChangeTransactionScope scope)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _scope = scope ?? throw new ArgumentNullException(nameof(scope));
        }

        public async Task<int> SaveChangesAsync()
        {
            var result = await (_context.SaveChangesAsync());
            _scope.TransactionId = Guid.NewGuid();
            return result;
        }
    }
}
