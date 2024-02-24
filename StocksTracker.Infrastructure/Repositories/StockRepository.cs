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
    public class StockRepository : IStockRepository
    {
        private readonly AppDBContext context;

        public StockRepository(AppDBContext context)
        {
            this.context = context;
        }
        public async Task<bool> AddStockAsync(Stock entity)
        {
            await context.Stoks.AddAsync(entity);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
