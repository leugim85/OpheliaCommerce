using Microsoft.AspNetCore.Mvc;
using OpheliaCommerce.App.Services;

namespace OpheliaCommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var result = await categoryService.Get();
            if (result is not null)
                return Ok(result);

            return NotFound();
        }

        [HttpGet("{id}", Name = nameof(GetCategoryById))]
        public async Task<IActionResult> GetCategoryById(int id) 
        {
            var result = await categoryService.GetCategoryById(id);
            if (result is null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoryToAdd category) 
        {
            var result = await categoryService.AddNewCategory(category);
            if (result.IsSucces)
                return Ok();

            return BadRequest(result.Message);
        }

    }
}
