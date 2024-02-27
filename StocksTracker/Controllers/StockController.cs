using Microsoft.AspNetCore.Mvc;
using StocksTracker.Domain.Entities;
using StocksTracker.Infrastructure.Services;
using StocksTracker.Repository.IServices;
using StocksTracker.WCFService;
using System.ServiceModel;

namespace StocksTracker.Controllers
{
    [ApiController]
    [Route("api/stock")]
    public class StockController : Controller
    {
        private readonly IStockService service;
        private readonly IEmialService emialService;
        private readonly IClientService clientService;

        public StockController(IStockService service, IEmialService emialService, IClientService clientService)
        {
            this.service = service;
            this.emialService = emialService;
            this.clientService = clientService;
            emialService.SetSenderInfo("boddaelmisry93@gmail.com", "csokfqqzuzdixijd");
            //emialService.SetSenderInfo("elmasry_abdallh@yahoo.com", "B@dda181993");
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

        [HttpGet]
        [Route("CallWCF")]
        public IActionResult GetStock()
        {
            IService1 service = new Service1();
            service.GetData();
            return Ok();
        }



        [HttpPost]
        [Route("createstocksList")]
        public async Task<IActionResult> AddStocksList(IEnumerable<Stock> stocks)
        {
            try
            {
                foreach(var stock in stocks)
                {
                    await service.CreateStockAsync(stock);
                }


                var emailbody = emialService.CreateBodyFromListToHTMl(stocks);
                var clients = await clientService.GetClientsAsync();
                string sendEmailErrors = null;
                foreach (var client in clients)
                {
                    var sendEmailResponse = emialService.SendMail(client.EmailAddress, emailbody, true);
                    if(sendEmailResponse != null && sendEmailResponse != "sent")
                    {
                        if(sendEmailErrors != null)
                            sendEmailErrors += "\n";
                            sendEmailErrors += ", " + client.EmailAddress;
                    }
                }
                if(sendEmailErrors != null)
                    return Problem(sendEmailErrors);

                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
