using Loan.Entity;

namespace Loan.Interface.Repositories
{
    public interface IClientRepository : ILoanRepository<Client>
    {
        public Task<Client?> GetByIdAsync(int id, bool includeAccounts);
        public Task<bool> IsClientExistsAsync(int id);
    }
}
