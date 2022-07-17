using Loan.Entity;

namespace Loan.Interface.Repositories
{
    public interface IAccountTransactionRepository: ILoanRepository<AccountTransaction>
    {
        public Task CreateTransactionsAsync(List<AccountTransaction> accountTransactions);
    }
}
