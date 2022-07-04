﻿using Loan.Data.Context;
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

        public async Task<IEnumerable<LookupSet>> GetAllAsync()
        {
            return await context.LookupSets.Include(ls => ls.Lookups).ToListAsync();
        }

        public async Task<LookupSet?> GetByIdAsync(int id)
        {
            return await context.LookupSets.Include(ls => ls.Lookups).FirstOrDefaultAsync(ls => ls.Id == id);
        }

        public Task<IEnumerable<LookupSet>?> SearchAsyc(string filter)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(LookupSet entity)
        {
            throw new NotImplementedException();
        }
    }
}
