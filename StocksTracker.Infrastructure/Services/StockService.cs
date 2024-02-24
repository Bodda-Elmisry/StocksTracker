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
    public class StockService : IStockService
    {
        private readonly IStockRepository repository;

        public StockService(IStockRepository repository)
        {
            this.repository = repository;
        }

        public async Task<bool> CreateStockAsync(Stock stock)
        {
            return await repository.AddStockAsync(stock);
        }
    }
}
