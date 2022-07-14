using Loan.Data.Context;
using Loan.Entity;
using Loan.Interface.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Loan.Repository
{
    public class LookupSetRepository : LoanRepositoryBase<LookupSet>, ILookupSetRepository
    {
        public LookupSetRepository(LoanDbContext dbcontext ) : base(dbcontext) { }
        public Task CreateAsync(LookupSet entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
        
        public async Task<PagedResult<LookupSet>> GetAllAsync(int page, int pageSize)
        {
            var query = context.LookupSets.Include(ls=>ls.Lookups);
            return await query.GetPagedAsync(page, pageSize);
        }

        public async Task<LookupSet?> GetByIdAsync(int id)
        {
            return await context.LookupSets.Include(ls => ls.Lookups).FirstOrDefaultAsync(ls => ls.Id == id);
        }
        
        public async Task<PagedResult<LookupSet>> SearchAsync(string filter, int page, int pageSize)
        {
            var query = context.LookupSets.Include(ls => ls.Lookups).Where(ls=>ls.Name.Contains(filter));
            return await query.GetPagedAsync(page, pageSize);
        }

        public Task UpdateAsync(LookupSet entity)
        {
            throw new NotImplementedException();
        }
    }
}
