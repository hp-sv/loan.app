﻿using AutoMapper;
using Loan.Data.Context;
using Loan.Entity;
using Loan.Interface.Constants;
using Loan.Interface.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Loan.Repository
{
    public class ClientRepository : LoanRepositoryBase<Client>, IClientRepository
    {

        private readonly IMapper _mapper;

        public ClientRepository(LoanDbContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public Task CreateAsync(Client client)
        {
            context.Clients.Add(client);
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(int id)
        {
            var client = await context.Clients.FirstAsync(a => a.Id == id);
            client.RecordStatusId = LookupIds.RecordStatus.Deleted;
            return;
        }

        public async Task UpdateAsync(Client client)
        {
            var clientToUpdate = await context.Clients.FirstAsync(c => c.Id == client.Id);
            _mapper.Map(client, clientToUpdate);
            return;
        }

        public async Task<IEnumerable<Client>> GetAllAsync()
        {
            return await context.Clients.OrderBy(c => c.FirstName).ThenBy(c => c.LastName).ToListAsync();
        }

        public async Task<Client?> GetByIdAsync(int id, bool includeAccounts)
        {
            if (includeAccounts)
                await context.Clients.Include(c => c.Accounts).Where(c => c.Id == id).FirstOrDefaultAsync();

            return await GetByIdAsync(id);
        }

        public async Task<Client?> GetByIdAsync(int id)
        {
            return await context.Clients.Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> IsClientExistsAsync(int id)
        {
            return await context.Clients.AnyAsync(c => c.Id == id);
        }
    }
}
