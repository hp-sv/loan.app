
using Loan.Entity;

namespace Loan.Interface.Services
{
    public interface IAccountTransactionGeneratorService
    {
        public List<AccountTransaction> Generate(Account account);        

    }
}
