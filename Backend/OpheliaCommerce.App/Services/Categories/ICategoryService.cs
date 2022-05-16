using OpheliaCommerce.Domain.Dtos;
using OpheliaCommerce.Domain.Infrastructure.Utilities;

namespace OpheliaCommerce.App.Services
{
    public interface ICategoryService
    {
        Task<GenericResponse<string>> AddNewCategory(CategoryToAdd categoryToAdd);
        Task<List<CategoryDto>> Get();
        Task<CategoryInfoDto> GetCategoryById(int id);
    }
}