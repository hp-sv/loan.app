
using Loan.Data.Context;

namespace Loan.Repository
{
    public class LoanRepositoryBase<T>
    {
        protected readonly LoanDbContext context;        
        protected LoanRepositoryBase(LoanDbContext loanDbContext)
        {            
            context = loanDbContext ?? throw new ArgumentNullException(nameof(loanDbContext));
        }        
    }
}
