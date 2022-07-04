namespace Loan.Interface.Repositories
{
    public interface ILoanRepository<T>
    {
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T?> GetByIdAsync(int id);
        public Task CreateAsync(T entity);
        public Task UpdateAsync(T entity);
        public Task DeleteAsync(int id);
        public Task<IEnumerable<T>?> SearchAsyc(string filter);
    }
}
