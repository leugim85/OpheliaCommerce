using OpheliaCommerce.Domain.Dtos;
using OpheliaCommerce.Domain.Infrastructure.Utilities;
using OpheliaCommerce.Domain.Models;

namespace OpheliaCommerce.App.Services
{
    public interface IProductService
    {
        Task<GenericResponse<string>> CreateProduct(ProductToAdd productToAdd);
        Task<GenericResponse<string>> DeleteProduct(int id);
        Task<ProductDto> GetProductById(int id);
        Task<List<ProductDto>> GetProducts();
        Task<GenericResponse<string>> UpdateProduct(ProductToUpdate productToUpdate);
        Task<GenericResponse<string>> UpdateProductStock(List<ProductToShopping> productToshoppingList);
    }
}