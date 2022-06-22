using Loan.Entity;
using Loan.Interface.Constants;
using Loan.Interface.Repositories;
using Loan.Interface.Services;

namespace Loan.Domain.Services
{
    public class ClientValidationService : ValidationServiceBase<Client>, IClientValidationService 
    {
        private readonly IClientRepository _clientRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IDateService _dateService;

        public ClientValidationService(
                IClientRepository clientRepository, 
                IAccountRepository accountRepository,
                IDateService dateService)
        {
            _clientRepository = clientRepository ?? throw new ArgumentNullException(nameof(clientRepository));
            _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
            _dateService = dateService ?? throw new ArgumentNullException(nameof(dateService));
        }
        public override Task ValidateForCreate(Client client)
        {
            validateAge(client);
            validateDob(client);

            return Task.CompletedTask;
        }

        private void validateAge(Client client)
        {            
            var age =(_dateService.CurrentDate.Subtract(client.Dob).TotalDays / 365);

            if (age < 18)
                _Erorrs.Add(new ValidationError { ErrorCode = ClientValidationErrorCodes.CLIENT_IS_UNDER_AGE, ErrorMessage = "Client must be 18 years old or above." });                        
        }

        private void validateDob(Client client)
        {
            var invalidDate = new DateTime(1900, 01, 01);
            
            if(client.Dob < invalidDate)
                _Erorrs.Add(new ValidationError { ErrorCode = ClientValidationErrorCodes.CLIENT_DATE_OF_BIRTH_ERROR, ErrorMessage = "Client must be born on or after first of January 1900" });
        }

        public override async Task ValidateForUpdate(Client client)
        {            
            validateAge(client);
            validateDob(client);
            await IsClientExists(client);

        }

        public override async Task ValidateForDelete(Client client)
        {
            await IsClientExists(client);
            await IsClientHasActiveAccount(client);
        }

        private async Task IsClientHasActiveAccount(Client client)
        {
            var clientAccounts = await _accountRepository.GetAccountByClientAsync(client.Id);

            if (clientAccounts != null)
                if (clientAccounts.Any(ca => ca.StatusId == LookupIds.AccountStatuses.Active))
                    _Erorrs.Add(new ValidationError { ErrorCode = ClientValidationErrorCodes.CLIENT_HAS_AN_ACTIVE_ACCOUNT, ErrorMessage = "Client has an active account." });
        }

        private async Task IsClientExists(Client client)
        {
            var isClientExist = await _clientRepository.IsClientExistsAsync(client.Id);

            if (!isClientExist)
                _Erorrs.Add(new ValidationError { ErrorCode = ClientValidationErrorCodes.CLIENT_DO_NOT_EXISTS, ErrorMessage = "Client does not exists." });
        }
    }
}
