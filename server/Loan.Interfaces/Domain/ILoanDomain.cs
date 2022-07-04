
namespace Loan.Interface.Domain
{
    public interface ILoanDomain<T>
    {
        public Task<T?> GetByIdAsync(int id);
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<bool> CreateAsync(T entity);
        public Task<bool> UpdateAsync(T entity);
        public Task<bool> DeleteAsync(int id);

        public Task<IEnumerable<T>?> SearchAsync(string filter);

    }
}
