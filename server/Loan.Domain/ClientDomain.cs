
using AutoMapper;
using Loan.Entity;
using Loan.Interface.Constants;
using Loan.Interface.Domain;
using Loan.Interface.Repositories;
using Loan.Interface.Services;

namespace Loan.Domain
{
    public class ClientDomain : IClientDomain
    {
        private readonly IClientRepository _repository;
        private readonly IChangeTransactionService _transactionService;
        private readonly IClientValidationService _validationService; 
        private readonly IMapper _mapper;

        public ClientDomain(IClientRepository repository, 
                IChangeTransactionService transactionService, 
                IClientValidationService validationService,
                IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _transactionService = transactionService ?? throw new ArgumentNullException(nameof(transactionService));
            _validationService = validationService ?? throw new ArgumentNullException(nameof(validationService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<bool> CreateAsync(Client client)
        {
            await _validationService.ValidateForCreate(client);

            if (_validationService.HasError)
                throw _validationService.GetException();

            if (client.EmergencyContactId.HasValue)
            {
                var emergencyContact = await _repository.GetByIdAsync(client.EmergencyContactId.Value);
                client.EmergencyContact = emergencyContact;
            }

            await _repository.CreateAsync(client);
            return (await _transactionService.SaveChangesAsync() >= 0);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var clientToDelete = await _repository.GetByIdAsync(id);

            await _validationService.ValidateForDelete(clientToDelete);
            if (_validationService.HasError)
                throw _validationService.GetException();

            clientToDelete.RecordStatusId = LookupIds.RecordStatus.Deleted;

            return (await _transactionService.SaveChangesAsync() >= 0);

        }

        public async Task<IEnumerable<Client>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Client?> GetByIdAsync(int id, bool includeAccounts)
        {
            return await _repository.GetByIdAsync(id, includeAccounts);
        }

        public async Task<Client?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<bool> IsClientExistsAsync(int id)
        {
            return await _repository.IsClientExistsAsync(id);
        }

        public async Task<IEnumerable<Client>?> SearchAsync(string filter)
        {
            return await _repository.SearchAsyc(filter);
        }

        public async Task<bool> UpdateAsync(Client client)
        {
            await _validationService.ValidateForUpdate(client);

            if (_validationService.HasError)
                throw _validationService.GetException();

            if (client.EmergencyContactId.HasValue)
            {
                var emergencyContact = await _repository.GetByIdAsync(client.EmergencyContactId.Value);
                client.EmergencyContact = emergencyContact;
            }

            await _repository.UpdateAsync(client);

            return (await _transactionService.SaveChangesAsync() >= 0);
        }
    }
}
