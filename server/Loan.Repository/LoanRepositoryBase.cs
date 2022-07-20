
using Loan.Data.Context;
using Loan.Entity;
using Microsoft.EntityFrameworkCore;

namespace Loan.Repository
{
    public class LoanRepositoryBase<T> where T : class
    {
        protected readonly LoanDbContext context;        
        protected LoanRepositoryBase(LoanDbContext loanDbContext)
        {            
            context = loanDbContext ?? throw new ArgumentNullException(nameof(loanDbContext));
        }

        public void UpdateChildEntities<T>(ICollection<T> source, ICollection<T> destination, Func<T, T, bool> Equals)
        {
            foreach (var sourceEntity in source)
            {                
                var destinationEntity = destination
                    .Where(d => Equals(d, sourceEntity))
                    .SingleOrDefault();

                if (destinationEntity != null)
                    // Update child
                    context.Entry(destinationEntity).CurrentValues.SetValues(sourceEntity);
                else                
                    context.Entry(sourceEntity).State = EntityState.Added;                
            }
        }
    }
}
