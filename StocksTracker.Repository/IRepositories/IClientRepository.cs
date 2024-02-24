using StocksTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StocksTracker.Repository.IRepositories
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetClients();
        Task<Client> GetClientAsync(int Id);
        Task<Client> GetClientByEmailAsync(string Email);
        Task<bool> CreateClientAsync(Client entity);
        Task<bool> UpdateClientAsync(Client entity);
        Task<bool> DeleteClientAsync(Client entity);
    }
}
