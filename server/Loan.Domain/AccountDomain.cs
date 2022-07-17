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
        private readonly IAccountTransactionRepository _accountTransactionRepository;
        private readonly IAccountCommentRepository _accountCommentRepository;
        private readonly IClientRepository _clientRepository;
        
        private readonly IDateService _dateService;
        private readonly IAccountTransactionGeneratorService _accountTransactionGeneratorService;
        private readonly IChangeTransactionService _transactionService;
        private readonly IAccountValidationService _validationService;
        private readonly IMapper _mapper;

        public AccountDomain(IAccountRepository accountRepository,
                IAccountTransactionRepository accountTransactionRepository,
                IAccountCommentRepository accountCommentRepository,
                IClientRepository clientRepository,
                IDateService dateService,
                IAccountTransactionGeneratorService accountTransactionGeneratorService,
                IChangeTransactionService transactionService,
                IAccountValidationService validationService, 
                IMapper mapper)
        {
            _repository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
            _accountTransactionRepository = accountTransactionRepository ?? throw new ArgumentNullException(nameof(accountTransactionRepository));
            _accountCommentRepository = accountCommentRepository ?? throw new ArgumentNullException(nameof(accountCommentRepository));
            _clientRepository = clientRepository ?? throw new ArgumentNullException(nameof(clientRepository));
            _dateService = dateService ?? throw new ArgumentNullException(nameof(dateService));
            _accountTransactionGeneratorService = accountTransactionGeneratorService ?? throw new ArgumentNullException(nameof(accountTransactionGeneratorService));            
            _transactionService = transactionService ?? throw new ArgumentNullException(nameof(transactionService));
            _validationService  = validationService ?? throw new ArgumentNullException(nameof(validationService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<bool> CreateAsync(Account account)
        {
            var client = await _clientRepository.GetByIdAsync(account.ClientId);
            account.Client = client;

            await _validationService.ValidateForCreate(account);

            if (_validationService.HasError)            
                throw _validationService.GetException();

            await _repository.CreateAsync(account);
            return (await _transactionService.SaveChangesAsync() >= 0);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var accountToDelete = await _repository.GetByIdAsync(id);

            await _validationService.ValidateForDelete(accountToDelete);
            if (_validationService.HasError)
                throw _validationService.GetException();

            accountToDelete.RecordStatusId = LookupIds.RecordStatus.Deleted;

            return (await _transactionService.SaveChangesAsync() >= 0);

        }

        public Task<Account?> GetAccountByClientAsync(int clientId)
        {
            throw new NotImplementedException();
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

            await _repository.UpdateAsync(account);

            return (await _transactionService.SaveChangesAsync() >= 0);

        }

        public async Task<bool> IsAccountExistsAsync(int id)
        {
            return await _repository.IsAccountExistsAsync(id);
        }
                
        public async Task<PagedResult<Account>> GetAllAsync(int pg, int pgSize)
        {
            return await _repository.GetAllAsync(pg, pgSize);
        }

        public async Task<PagedResult<Account>> SearchAsync(string filter, int pg, int pgSize)
        {
            return await _repository.SearchAsync(filter, pg, pgSize);
        }

        public async Task<bool> Approve(Account account)
        {
            await _validationService.ValidateForApprove(account);

            if (_validationService.HasError)
                throw _validationService.GetException();

            account.StatusId = LookupIds.AccountStatuses.Approved;
            account.StartDate = _dateService.CurrentDate;

            var transactions = _accountTransactionGeneratorService.Generate(account);
            var comments = account.AccountComments;

            
            await _accountTransactionRepository.CreateTransactionsAsync(transactions);
            await _accountCommentRepository.CreateCommentsAsync(comments.ToList());            
            await _repository.UpdateAsync(account);

            return (await _transactionService.SaveChangesAsync() >= 0);

        }

        public async Task<bool> Cancel(Account account)
        {            
            account.StatusId = LookupIds.AccountStatuses.Cancelled;                      
            var comments = account.AccountComments;

            await _accountCommentRepository.CreateCommentsAsync(comments.ToList());
            await _repository.UpdateAsync(account);

            return (await _transactionService.SaveChangesAsync() >= 0);
        }

        public async Task<bool> Decline(Account account)
        {
            account.StatusId = LookupIds.AccountStatuses.Declined;            
            var comments = account.AccountComments;

            await _accountCommentRepository.CreateCommentsAsync(comments.ToList());
            await _repository.UpdateAsync(account);

            return (await _transactionService.SaveChangesAsync() >= 0);
        }
    }
}
