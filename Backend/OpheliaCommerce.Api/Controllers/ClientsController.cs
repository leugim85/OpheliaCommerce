using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpheliaCommerce.App.Services;
using OpheliaCommerce.Domain.Models;

namespace OpheliaCommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService clientService;

        public ClientsController(IClientService clientService)
        {
            this.clientService = clientService ?? throw new ArgumentNullException(nameof(clientService));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() 
        {
            var result = await clientService.GetAllClients();
            if (result is null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("{id}", Name = nameof(GetClientById))]
        public async Task<IActionResult> GetClientById(int id) 
        {
            var result = await clientService.GetClientById(id);
            if (result is not null)
                return Ok(result);

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddClient(ClientToAdd client) 
        {
            var result = await clientService.AddClient(client);
            if (result.IsSucces)
                return Ok();

            return BadRequest(result.Message);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteClient(int id) 
        {
            var result = await clientService.DeleteClientById(id);
            if (result.IsSucces)
                return Ok();

            return NotFound();
        }
    }
}
