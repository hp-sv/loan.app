using AutoMapper;
using Loan.Entity;
using Loan.Interface.Constants;
using Loan.Interface.Domain;
using Loan.Interface.Repositories;
using Loan.Interface.Services;

namespace Loan.Domain
{
    public class AccountDomain : IAccountDomain
    {
        private readonly IAccountRepository _repository;        
        private readonly IChangeTransactionService _transactionService;
        private readonly IAccountValidationService _validationService;
        private readonly IMapper _mapper;

        public AccountDomain(IAccountRepository accountRepository,                
                IChangeTransactionService transactionService,
                IAccountValidationService validationService, 
                IMapper mapper)
        {
            _repository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));        
            _transactionService = transactionService ?? throw new ArgumentNullException(nameof(transactionService));
            _validationService  = validationService ?? throw new ArgumentNullException(nameof(validationService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<bool> CreateAsync(Account account)
        {
            await _validationService.ValidateForCreate(account);

            if (_validationService.HasError)            
                throw _validationService.GetException();

            _repository.Create(account);
            return (await _transactionService.SaveChangesAsync() >= 0);
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Account?> GetAccountByClientAsync(int clientId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Account>> GetAllAsync()
        {
            var accounts = await _repository.GetAllAsync();

            if (accounts == null)
                throw _validationService.CreateException(AccountValidationErrorCodes.ACCOUNT_DOES_NOT_EXISTS, "Accounts do not exist.");

            return accounts;
        }
        public async Task<Account?> GetByIdAsync(int id)
        {
            var account = await _repository.GetByIdAsync(id);

            if(account == null)
                throw _validationService.CreateException(AccountValidationErrorCodes.ACCOUNT_DOES_NOT_EXISTS, "Account does not exists.");            

            return account;
        }

        public async Task<Account?> GetByIdAsync(int id, bool includeTransactions)
        {
            var accounts = await _repository.GetByIdAsync(id, includeTransactions);

            if (accounts == null)
                throw _validationService.CreateException(AccountValidationErrorCodes.ACCOUNT_DOES_NOT_EXISTS, "Account does not exists.");            

            return accounts;

        }

        public async Task<bool> UpdateAsync(Account account)
        {            
            await _validationService.ValidateForUpdate(account);

            if (_validationService.HasError)
                throw _validationService.GetException();

            _repository.Update(account);

            return (await _transactionService.SaveChangesAsync() >= 0);

        }

        public async Task<bool> IsAccountExistsAsync(int id)
        {
            return await _repository.IsAccountExistsAsync(id);
        }       



    }
}
