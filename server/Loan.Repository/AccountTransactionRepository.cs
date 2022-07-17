using AutoMapper;
using Loan.Data.Context;
using Loan.Entity;
using Loan.Interface.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Loan.Repository
{
    public class AccountTransactionRepository : LoanRepositoryBase<AccountTransaction>, IAccountTransactionRepository
    {
        private readonly IMapper _mapper;
        public AccountTransactionRepository(LoanDbContext loanDbContext, IMapper mapper) : base(loanDbContext)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public Task CreateAsync(AccountTransaction accountTransaction)
        {
            context.AccountTransactions.Add(accountTransaction);
            return Task.CompletedTask;
        }

        public Task CreateTransactionsAsync(List<AccountTransaction> accountTransactions)
        {
            foreach(var transaction in accountTransactions)
                context.AccountTransactions.Add(transaction);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResult<AccountTransaction>> GetAllAsync(int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<AccountTransaction?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResult<AccountTransaction>> SearchAsync(string filter, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(AccountTransaction accountTransaction)
        {
            var accountTransactionToUpdate = await context.AccountTransactions.FirstOrDefaultAsync(a => a.Id == accountTransaction.Id);

            _mapper.Map(accountTransaction, accountTransactionToUpdate);

            return;
        }
    }
}
