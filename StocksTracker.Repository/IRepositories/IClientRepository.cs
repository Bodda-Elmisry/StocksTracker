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
        Task<bool> CreateClientsAsync(Client entity);
        Task<bool> UpdateClientsAsync(Client entity);
        Task<bool> DeleteClientsAsync(Client entity);
    }
}
