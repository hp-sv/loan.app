using Loan.Entity;

namespace Loan.Interface.Domain
{
    public interface IAccountDomain : ILoanDomain<Account>
    {
        public Task<Account?> GetAccountByClientAsync(int clientId);
        public Task<Account?> GetByIdAsync(int id, bool includeTransactions);
        public Task<bool> IsAccountExistsAsync(int id);

        public Task<bool> Approve(Account account);
        public Task<bool> Cancel(Account account);
        public Task<bool> Decline(Account account);


    }
}
