using Microsoft.AspNetCore.Mvc;
using StocksTracker.Domain.Entities;
using StocksTracker.Repository.IServices;

namespace StocksTracker.Controllers
{
    [ApiController]
    [Route("api/Client")]
    public class ClientController : Controller
    {
        private readonly IClientService service;
        private readonly INationalityService nationalityService;

        public ClientController(IClientService service, INationalityService nationalityService)
        {
            this.service = service;
            this.nationalityService = nationalityService;
        }

        [HttpGet]
        [Route("clients")]
        public async Task<IActionResult> Index()
        {
            try
            {
                var clients = await service.GetClientsAsync();
                return Ok(clients);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("clientbyid")]
        public async Task<IActionResult> GetClientById(int Id)
        {
            try
            {
                var client = await service.GetClientByIdAsync(Id);
                return Ok(client);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("clientbyemail")]
        public async Task<IActionResult> GetClientByEmail(string Email)
        {
            try
            {
                var client = await service.GetClientByEmailAsync(Email);
                return Ok(client);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetNationalitiyes")]
        public async Task<IActionResult> GetNationalitiesList()
        {
            try
            {
                var nationalities = await nationalityService.GetAll();
                return Ok(nationalities);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("createclient")]
        public async Task<IActionResult> CreateClient(Client client)
        {
            try
            {
                if(await service.CreateClientAsync(client))
                {
                    return Ok(client);
                }
                else
                {
                    return BadRequest("Client already exist");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("updateclient")]
        public async Task<IActionResult> UpdateClient(Client client)
        {
            try
            {
                var updated = await service.UpdateClientAsync(client);
                return Ok(client);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("deleteclient")]
        public async Task<IActionResult> DeleteClient([FromBody]int id)
        {
            try
            {
                var deleted = await service.DeleteClientAsync(id);
                return Ok(deleted);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}
