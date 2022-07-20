using Loan.Entity;

namespace Loan.Interface.Repositories
{
    public interface IAccountRepository: ILoanRepository<Account>
    {
        public Task<IEnumerable<Account>?> GetAccountByClientAsync(int clientId);
        public Task<Account?> GetByIdAsync(int id, bool includeTransactions);
        public Task<bool> IsAccountExistsAsync(int id);

        public Task CreateCommentAsync(AccountComment comment);

    }
}
