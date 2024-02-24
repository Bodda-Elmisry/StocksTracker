using Microsoft.EntityFrameworkCore;
using StocksTracker.Domain.Entities;
using StocksTracker.Infrastructure.Data;
using StocksTracker.Repository.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StocksTracker.Infrastructure.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly AppDBContext context;

        public ClientRepository(AppDBContext context)
        {
            this.context = context;
        }

        public async Task<bool> CreateClientAsync(Client entity)
        {
            await context.Clients.AddAsync(entity);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteClientAsync(Client entity)
        {
            context.Clients.Remove(entity);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<Client> GetClientAsync(int Id)
        {
            return await context.Clients.FirstOrDefaultAsync(c => c.Id == Id);
        }

        public async Task<Client> GetClientByEmailAsync(string Email)
        {
            return await context.Clients.FirstOrDefaultAsync(c => c.EmailAddress == Email);
        }

        public async Task<IEnumerable<Client>> GetClients()
        {
            return await context.Clients.ToListAsync();
        }

        public async Task<bool> UpdateClientAsync(Client entity)
        {
            context.Clients.Update(entity);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
