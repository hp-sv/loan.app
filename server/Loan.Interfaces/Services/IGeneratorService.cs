
using Loan.Entity;

namespace Loan.Interface.Services
{
    public interface IGeneratorService<T, E>
    {
        public List<T> Generate(E account);        

    }
    public interface IAccountTransactionGeneratorService : IGeneratorService<AccountTransaction, Account> { }
}
