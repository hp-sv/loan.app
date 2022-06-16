using Loan.Data.Context;
using Loan.Entity;
using Loan.Interface.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Loan.Repository
{
    public class LookupSetRepository : LoanRepositoryBase<LookupSet>, ILookupSetRepository
    {
        public LookupSetRepository(LoanDbContext dbcontext ) : base(dbcontext) { }
        public void Create(LookupSet entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<LookupSet>> GetAllAsync()
        {
            return await context.LookupSets.Include(ls => ls.Lookups).ToListAsync();
        }

        public async Task<LookupSet?> GetByIdAsync(int id)
        {
            return await context.LookupSets.Include(ls => ls.Lookups).FirstOrDefaultAsync(ls => ls.Id == id);
        }

        public void Update(LookupSet entity)
        {
            throw new NotImplementedException();
        }
    }
}
