using StocksTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StocksTracker.Repository.IRepositories
{
    public interface IStockRepository
    {
        Task<bool> AddStockAsync(Stock entity);
    }
}
