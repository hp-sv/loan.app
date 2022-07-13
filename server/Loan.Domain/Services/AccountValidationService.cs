using Loan.Entity;
using Loan.Interface.Constants;
using Loan.Interface.Domain;
using Loan.Interface.Repositories;
using Loan.Interface.Services;

namespace Loan.Domain.Services
{
    public class AccountValidationService : ValidationServiceBase<Account>, IAccountValidationService
    {
        private readonly ILookupSetDomain _lookupSetDomain;
        private readonly IClientRepository _clientRepository;
        private readonly IAccountRepository _accountRepository;

        public AccountValidationService(
                IClientRepository clientRepository,
                IAccountRepository accountRepository,
                ILookupSetDomain lookupSetDomain)
        {
            _lookupSetDomain = lookupSetDomain ?? throw new ArgumentNullException(nameof(lookupSetDomain));
            _clientRepository = clientRepository ?? throw new ArgumentNullException(nameof(clientRepository));
            _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));   
        }

        public override async Task ValidateForCreate(Account account)
        {
            await IsValidClient(account);            
            await IsValidLookup(LookupIds.LookupSetId.DurationTypeSetId, account.DurationTypeId, "Duration", AccountValidationErrorCodes.INVALID_DURATION_TYPE);            
            await IsValidLookup(LookupIds.LookupSetId.RepaymentScheduleId, account.RepaymentTypeId,"Repayment schedule", AccountValidationErrorCodes.INVALID_REPAYMENT_TYPE);            
            await IsValidLookup(LookupIds.LookupSetId.RepaymentScheduleId, account.RepaymentTypeId, "Status", AccountValidationErrorCodes.INVALID_REPAYMENT_TYPE);
            
        }
        
        private async Task IsValidClient(Account account)
        {
            var isClientExist = await _clientRepository.IsClientExistsAsync(account.ClientId);

            if (!isClientExist)
                _Erorrs.Add(new ValidationError {Code = AccountValidationErrorCodes.IVALID_CLIENT, Message="Client does not exists."});
        
        }
      
        private async Task IsValidLookup(int lookupSetId, int lookupId, string lookupSetName, int errorCode)
        {
            var lookupSet = await _lookupSetDomain.GetByIdAsync(lookupSetId);

            if (lookupSet == null)
            {
                _Erorrs.Add(new ValidationError { Code = CommonErrorCodes.SYSTEM_CONFIGURATION_ERROR, Message = $"System configuration errorf - {lookupSetName} is not defined." });
                return;
            }

            if (!(lookupSet.Lookups.Any(l => l.Id == lookupId)))
                _Erorrs.Add(new ValidationError { Code = errorCode, Message = $"Invalid {lookupSetName}."});
        }

        public override async Task ValidateForUpdate(Account account)
        {
            await IsAccountExists(account);
        }

        private async Task IsAccountExists(Account account)
        {
            if(account!=null)
            {
                var isClientExist = await _accountRepository.IsAccountExistsAsync(account.Id);

                if (!isClientExist)
                    _Erorrs.Add(new ValidationError { Code = AccountValidationErrorCodes.ACCOUNT_DOES_NOT_EXISTS, Message = "Account does not exists." });
            }            
        }

        private async Task IsAccountStatus(Account account)
        {
            var activeAccounts = new List<int> { 
                LookupIds.AccountStatuses.Active, 
                LookupIds.AccountStatuses.Approved, 
                LookupIds.AccountStatuses.Pending };

            if (account != null && activeAccounts.Contains(account.StatusId))
             _Erorrs.Add(new ValidationError { Code = AccountValidationErrorCodes.ACCOUNT_IS_ACTIVE, Message = "Account is active." });
            
        }

        public override async Task ValidateForDelete(Account account)
        {
            await IsAccountExists(account);
            await IsAccountStatus(account);
            
        }
    }
}
