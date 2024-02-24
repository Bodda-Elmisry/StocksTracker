using StocksTracker.Domain.Entities;
using StocksTracker.Repository.IRepositories;
using StocksTracker.Repository.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StocksTracker.Infrastructure.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository repository;

        public ClientService(IClientRepository clientRepository)
        {
            this.repository = clientRepository;
        }

        public async Task<bool> CreateClientAsync(Client client)
        {
            var clientExist = await GetClientByEmailAsync(client.EmailAddress);
            if (clientExist != null)
            {
                return false;
            }
            return await repository.CreateClientAsync(client);
        }

        public async Task<bool> DeleteClientAsync(int ClientId)
        {
            var client = await GetClientByIdAsync(ClientId);
            if(client != null)
            {
                return await repository.DeleteClientAsync(client);
            }
            return false;
        }

        public async Task<Client> GetClientByIdAsync(int ClientId)
        {
            return await repository.GetClientAsync(ClientId);
        }

        public async Task<Client> GetClientByEmailAsync(string Email)
        {
            return await repository.GetClientByEmailAsync(Email);
        }

        public async Task<IEnumerable<Client>> GetClientsAsync()
        {
            return await repository.GetClients();
        }

        public async Task<bool> UpdateClientAsync(Client client)
        {
            return await repository.UpdateClientAsync(client);
        }
    }
}
