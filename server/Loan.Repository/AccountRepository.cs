using AutoMapper;
using Loan.Data.Context;
using Loan.Entity;
using Loan.Interface.Constants;
using Loan.Interface.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Loan.Repository
{
    public class AccountRepository : LoanRepositoryBase<Account>, IAccountRepository 
    {
        private readonly IMapper _mapper;
        public AccountRepository(LoanDbContext loanDbContext, IMapper mapper) : base(loanDbContext)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public Task CreateAsync(Account account)
        {
            context.Accounts.Add(account);
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(int id)
        {
            var account = await context.Accounts.FirstAsync(a => a.Id == id);
            account.RecordStatusId = LookupIds.RecordStatus.Deleted;
            return;
        }

        public async Task<IEnumerable<Account>?> GetAccountByClientAsync(int clientId)
        {
            return await context.Accounts.Include(a => a.Client).Where(a => a.ClientId == clientId).ToListAsync();
        }

        public async Task<IEnumerable<Account>> GetAllAsync()
        {
            return await context.Accounts.Include(a=>a.Client).OrderBy(a => a.Client.FirstName).ThenBy(a => a.Client.LastName).ToListAsync();
        }

        public async Task<Account?> GetByIdAsync(int id)
        {
            return await context.Accounts.Include(a => a.Client).FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Account?> GetByIdAsync(int id, bool includeTransactions)
        {
            if(!includeTransactions)
                return await GetByIdAsync(id);

            return await context.Accounts.Include(a => a.Client).Include(a => a.AccountTransactions).FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<bool> IsAccountExistsAsync(int id)
        {
            return await context.Accounts.AnyAsync(a => a.Id == id);
        }

        public async Task UpdateAsync(Account account)
        {
            var accountToUpdate = await context.Accounts.FirstOrDefaultAsync(a => a.Id == account.Id);

            _mapper.Map(account, accountToUpdate);

            return;

        }
    }
}
