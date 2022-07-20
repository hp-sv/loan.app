using Loan.Entity;
namespace Loan.Interface.Services
{
    public interface IAccountValidationService: IEntityValidationService<Account>
    {        
        public Task ValidateForApprove(Account entity);
        public Task ValidateForDecline(Account entity);
        public Task ValidateForCancel(Account entity);        
    }
}
