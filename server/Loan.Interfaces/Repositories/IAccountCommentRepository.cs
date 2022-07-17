using Loan.Entity;


namespace Loan.Interface.Repositories
{
    public interface IAccountCommentRepository : ILoanRepository<AccountComment>
    {
        public Task CreateCommentsAsync(List<AccountComment> accountComments);
    }
}
