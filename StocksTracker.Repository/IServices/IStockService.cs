using StocksTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StocksTracker.Repository.IServices
{
    public interface IStockService
    {
        Task<bool> CreateStockAsync(Stock stock);
    }
}
