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
            await IsClientExists(account);
            await IsClientHasEmergencyContact(account);
            await IsValidRate(account);
            await IsValidLookup(LookupIds.LookupSetId.DurationTypeSetId, account.DurationTypeId, "Duration", AccountValidationErrorCodes.INVALID_DURATION_TYPE);            
            await IsValidLookup(LookupIds.LookupSetId.RepaymentScheduleId, account.RepaymentTypeId,"Repayment schedule", AccountValidationErrorCodes.INVALID_REPAYMENT_TYPE); 
        }
        
        private async Task IsClientExists(Account account)
        {
            var isClientExist = await _clientRepository.IsClientExistsAsync(account.ClientId);

            if (!isClientExist)
                _Erorrs.Add(new ValidationError {Code = AccountValidationErrorCodes.IVALID_CLIENT, Message="Client does not exists."});
            
        }
        private async Task IsClientHasEmergencyContact(Account account)
        {
            var client = await _clientRepository.GetByIdAsync(account.ClientId);

            if (client != null && !client.EmergencyContactId.HasValue)
                _Erorrs.Add(new ValidationError { Code = AccountValidationErrorCodes.ACCOUNT_CLIENT_NO_EMERGENCY_CONTACT, Message = "Client must have an emergency contact." });            

        }
        private Task IsValidRate(Account account)
        {            
            if (account.Rate < 1 || account.Rate > 10)
                _Erorrs.Add(new ValidationError { Code = AccountValidationErrorCodes.ACCOUNT_RATE_IS_INVALID, Message = "Account rate must be between 1 and 10;" });
            return Task.CompletedTask;
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
            await IsClientHasEmergencyContact(account);
            await IsValidRate(account);
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

        private  async Task IsAccountStatusValidToApprove(Account account)
        {
            var validStatusToApprove = new List<int> {                
                LookupIds.AccountStatuses.Pending,        
                LookupIds.AccountStatuses.Cancelled };        

            if (account != null && !validStatusToApprove.Contains(account.StatusId))
                _Erorrs.Add(new ValidationError { Code = AccountValidationErrorCodes.ACCOUNT_STATUS_IS_NOT_PENDING_OR_CANCELLED, Message = "Account is not pending or cancelled." });
        }

        public override async Task ValidateForDelete(Account account)
        {
            await IsAccountExists(account);
            await IsAccountStatus(account);            
        }

        public async Task ValidateForApprove(Account account)
        {            
            await IsAccountStatusValidToApprove(account);
            await IsAccountClientOverLimit(account);
        }

        private Task IsAccountClientOverLimit(Account account)
        {
            // TODO: Implement the rule
            return Task.CompletedTask;
        }

        public Task ValidateForDecline(Account entity)
        {
            throw new NotImplementedException();
        }

        public Task ValidateForCancel(Account entity)
        {
            throw new NotImplementedException();
        }
    }
}
