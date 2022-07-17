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
            return await context.Accounts
                .Include(a => a.AccountTransactions)
                .ThenInclude(at => at.TransactionType)
                .Include(a => a.AccountComments)
                .ThenInclude(ac => ac.Status)
                .Include(a => a.Client)
                .Where(a => a.ClientId == clientId).ToListAsync();
        }
        
        public async Task<PagedResult<Account>> GetAllAsync(int page, int pageSize)
        {
            var query = context.Accounts
                     .Include(a => a.AccountComments)
                    .ThenInclude(ac => ac.Status)
                    .Include(a => a.AccountTransactions)
                    .ThenInclude(at => at.TransactionType)
                    .Include(a => a.Client)
                    .OrderBy(a => a.Client.FirstName).ThenBy(a => a.Client.LastName);
            return await query.GetPagedAsync(page, pageSize);
        }

        public async Task<Account?> GetByIdAsync(int id)
        {
            return await context.Accounts
                .Include(a=>a.AccountComments)
                .ThenInclude(ac=>ac.Status)
                .Include(a=>a.AccountTransactions)
                .ThenInclude(at=>at.TransactionType)
                .Include(a => a.Client)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Account?> GetByIdAsync(int id, bool includeTransactions)
        {
            if(!includeTransactions)
                return await GetByIdAsync(id);

            return await context.Accounts
                .Include(a => a.AccountComments)
                .ThenInclude(ac => ac.Status)
                .Include(a => a.AccountTransactions)
                .ThenInclude(at => at.TransactionType)
                .Include(a => a.Client)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<bool> IsAccountExistsAsync(int id)
        {
            return await context.Accounts.AnyAsync(a => a.Id == id);
        }

        
        public async Task<PagedResult<Account>> SearchAsync(string filter, int page, int pageSize)
        {
            filter = filter.ToLower();
            var query = context.Accounts
                    .Include(a => a.AccountComments)
                    .ThenInclude(ac => ac.Status)
                    .Include(a => a.AccountTransactions)
                    .ThenInclude(at => at.TransactionType)
                    .Include(a => a.Client)
                    .Where(
                    a => a.Client.FirstName.ToLower().Contains(filter)
                    || a.Client.MiddleName.ToLower().Contains(filter)
                    || a.Client.LastName.ToLower().Contains(filter)
                    );

            return await query.GetPagedAsync(page, pageSize);
        }

        public async Task UpdateAsync(Account account)
        {
            var accountToUpdate = await context.Accounts.FirstOrDefaultAsync(a => a.Id == account.Id);

            _mapper.Map(account, accountToUpdate);

            return;
        }
    }
}
