using Loan.Entity;
using Loan.Interface.Domain;
using Loan.Interface.Repositories;
using Loan.Interface.Services;

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
                

        public async Task<PagedResult<LookupSet>> GetAllAsync(int pg, int pgSize)
        {
            return await _lookupSetRepository.GetAllAsync(pg, pgSize);
        }

        public async Task<LookupSet?> GetByIdAsync(int id)
        {
            return await _lookupSetRepository.GetByIdAsync(id);
        }

        public async Task<PagedResult<LookupSet>> SearchAsync(string filter, int pg, int pgSize)
        {
            return await _lookupSetRepository.SearchAsync(filter, pg, pgSize);
        }
        

        public Task<bool> UpdateAsync(LookupSet entity)
        {
            throw new NotImplementedException();
        }
    }
}
