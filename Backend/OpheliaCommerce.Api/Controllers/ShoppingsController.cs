using Microsoft.AspNetCore.Mvc;
using OpheliaCommerce.App.Services;
using OpheliaCommerce.Domain.Models;

namespace OpheliaCommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingsController : ControllerBase
    {
        private readonly IShoppingService shoppingService;

        public ShoppingsController(IShoppingService shoppingService)
        {
            this.shoppingService = shoppingService ?? throw new ArgumentNullException(nameof(shoppingService));
        }

        [HttpPost]
        public async Task<IActionResult> AddShopping(ShoppingRequest shoppingRequest) 
        {
            var result = await shoppingService.AddShopping(shoppingRequest);
            if (result.IsSucces)
                return Ok();

            return BadRequest(result.Message);
        }

        [HttpGet("{clientId}")]
        public async Task<IActionResult> GetShoppingByClient(int clientId) 
        {
            var result = await shoppingService.GetShoppingInfoByClient(clientId);
            if (result is not null)
                return Ok(result);
            return NotFound();
        }
    }
}
