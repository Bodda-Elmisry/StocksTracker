using Microsoft.EntityFrameworkCore;
using StocksTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StocksTracker.Infrastructure.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Client>().HasIndex(c => c.EmailAddress).IsUnique();
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Stock> Stoks { get; set; }
    }
}
