using Loan.Data.Context;
using Loan.Entity;
using Loan.Interface.Repositories;

namespace Loan.Repository
{
    public class AccountCommentRepository : LoanRepositoryBase<AccountComment>, IAccountCommentRepository
    {
        public AccountCommentRepository(LoanDbContext loanDbContext) : base(loanDbContext)
        {

        }        
        public Task CreateAsync(AccountComment accountComment)
        {
            context.AccountComments.Add(accountComment);
            return Task.CompletedTask;
        }

        public Task CreateCommentsAsync(List<AccountComment> accountComments)
        {
            foreach(var comment in accountComments.Where(comment=> comment.Id <=0 ))            
                context.AccountComments.Add(comment);            
            return Task.CompletedTask;
            
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResult<AccountComment>> GetAllAsync(int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<AccountComment?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResult<AccountComment>> SearchAsync(string filter, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(AccountComment entity)
        {
            throw new NotImplementedException();
        }
    }
}
