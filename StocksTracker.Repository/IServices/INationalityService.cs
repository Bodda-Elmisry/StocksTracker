using StocksTracker.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StocksTracker.Repository.IServices
{
    public interface INationalityService
    {
        Task<IEnumerable<Nationality>> GetAll();
    }
}
