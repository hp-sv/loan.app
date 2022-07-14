
using Loan.Entity;

namespace Loan.Interface.Domain
{
    public interface ILoanDomain<T> where T: class
    {
        public Task<T?> GetByIdAsync(int id);
        public Task<PagedResult<T>> GetAllAsync(int pg, int pgSize);        
        public Task<bool> CreateAsync(T entity);
        public Task<bool> UpdateAsync(T entity);
        public Task<bool> DeleteAsync(int id);
                
        public Task<PagedResult<T>> SearchAsync(string filter, int pg, int pgSize);

    }
}
