using Loan.Entity;

namespace Loan.Interface.Repositories
{
    public interface ILoanRepository<T> where T : class
    {
        public Task<PagedResult<T>> GetAllAsync(int page, int pageSize);
                
        public Task<T?> GetByIdAsync(int id);
        public Task CreateAsync(T entity);
        public Task UpdateAsync(T entity);
        public Task DeleteAsync(int id);
        public Task<PagedResult<T>> SearchAsync(string filter,int page, int pageSize);
        public void UpdateChildEntities<T>(ICollection<T> source, ICollection<T> destination, Func<T, T, bool> Equals);
    }
}
