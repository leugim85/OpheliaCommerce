using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OpheliaCommerce.App.Validators;
using OpheliaCommerce.Data.Context;
using OpheliaCommerce.Domain.Dtos;
using OpheliaCommerce.Domain.Entities;
using OpheliaCommerce.Domain.Infrastructure.Utilities;

namespace OpheliaCommerce.App.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly EcommerceContext context;
        private readonly IMapper mapper;
        private readonly IValidator validator;

        public CategoryService(EcommerceContext context, IMapper mapper, IValidator validator)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.validator = validator ?? throw new ArgumentNullException(nameof(validator));
        }


        public async Task<GenericResponse<string>> AddNewCategory(CategoryToAdd categoryToAdd)
        {
            var isValid = await validator.ValidateCategoryToAdd(categoryToAdd);
            if (!isValid.IsSucces)
                return new GenericResponse<string>(false, isValid.Message);

            var category = mapper.Map<Category>(categoryToAdd);
            var result = context.Categories.Add(category);
            await context.SaveChangesAsync();
            if (result is null)
                return new GenericResponse<string>(false, "Ocurrio un error durante la conexión");

            return new GenericResponse<string>();
        }

        public async Task<List<CategoryDto>> Get()
        {
            var categories = await context.Categories.ToListAsync();
            if (categories is null)
                return null;

            var categoriesDto = mapper.Map<List<CategoryDto>>(categories);
            return categoriesDto;
        }

        public async Task<CategoryInfoDto> GetCategoryById(int id)
        {
            var response = await context.Categories.Include(c => c.Products).FirstOrDefaultAsync(c => c.Id == id);
            if (response is null)
                return null;

            CategoryInfoDto categoryDetails = new CategoryInfoDto
            {
                Name = response.Name,
                Id = response.Id,
                Description = response.Description,
                IsActive = response.IsActive,
                Products = response.Products.Select(c => new ProductByClassDto
                {
                    Name = c.Name,
                    Id = c.Id,
                    Stock = c.Stock,
                }).ToList()
            };

            return categoryDetails;
        }
    }
}
