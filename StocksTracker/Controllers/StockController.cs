using Microsoft.AspNetCore.Mvc;
using StocksTracker.Domain.Entities;
using StocksTracker.Repository.IServices;

namespace StocksTracker.Controllers
{
    [ApiController]
    [Route("api/stock")]
    public class StockController : Controller
    {
        private readonly IStockService service;

        public StockController(IStockService service)
        {
            this.service = service;
        }

        [HttpPost]
        [Route("createstock")]
        public async Task<IActionResult> AddStock(Stock stock)
        {
            try
            {
                var added = await service.CreateStockAsync(stock);
                return Ok(added);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
