namespace Loan.Interface.Repositories
{
    public interface ILoanRepository<T>
    {
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T?> GetByIdAsync(int id);
        public void Create(T entity);
        public void Update(T entity);
        public void Delete(int id);
    }
}
