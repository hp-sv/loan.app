using Loan.Entity;
using Loan.Interface.Domain;
using Loan.Interface.Repositories;

namespace Loan.Domain
{
    public class LookupSetDomain : ILookupSetDomain
    {

        private readonly ILookupSetRepository _lookupSetRepository;
        public LookupSetDomain(ILookupSetRepository lookupSetRepository)
        {
            _lookupSetRepository = lookupSetRepository ?? throw new ArgumentNullException(nameof(lookupSetRepository));
        }

        public Task<bool> CreateAsync(LookupSet entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<LookupSet>> GetAllAsync()
        {
            return await _lookupSetRepository.GetAllAsync();
        }

        public async Task<LookupSet?> GetByIdAsync(int id)
        {
            return await _lookupSetRepository.GetByIdAsync(id);
        }

        public Task<bool> UpdateAsync(LookupSet entity)
        {
            throw new NotImplementedException();
        }
    }
}
