using Loan.Entity;

namespace Loan.Interface.Domain
{
    public interface IClientDomain: ILoanDomain<Client>
    {
        public Task<Client?> GetByIdAsync(int id, bool includeAccounts);
        public Task<bool> IsClientExistsAsync(int id);
    }
}
