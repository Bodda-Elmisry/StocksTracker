using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StocksTracker.WCFService.Models
{
    internal class Stock
    {
        public int Id { get; set; }
        public decimal V { get; set; }
        public decimal VM { get; set; }
        public decimal O { get; set; }
        public decimal C { get; set; }
        public decimal H { get; set; }
        public decimal L { get; set; }
        public decimal T { get; set; }
        public decimal N { get; set; }
    }
}
