using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpheliaCommerce.App.Services;
using OpheliaCommerce.Domain.Models;

namespace OpheliaCommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() 
        {
            var result = await productService.GetProducts();
            if (result is null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("{id}", Name = nameof(GetProductById))]
        public async Task<IActionResult> GetProductById(int id)
        {
            var result = await productService.GetProductById(id);
            if (result is not null)
                return Ok(result);

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductToAdd productToAdd)
        {
            var result = await productService.CreateProduct(productToAdd);
            if (result.IsSucces)
                return Ok();

            return BadRequest(result.Message);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await productService.DeleteProduct(id);
            if (result.IsSucces)
                return Ok();

            return NotFound();
        }

        [HttpPut]

        public async Task<IActionResult> UpdateProduct(ProductToUpdate productToUpdate) 
        {
            var result = await productService.UpdateProduct(productToUpdate);
            if (result.IsSucces)
                return Ok();

            return BadRequest(result.Message);
        }
    }
}
