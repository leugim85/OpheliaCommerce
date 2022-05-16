using OpheliaCommerce.App.Services;
using OpheliaCommerce.Domain.Infrastructure.Utilities;
using OpheliaCommerce.Domain.Models;

namespace OpheliaCommerce.App.Validators
{
    public interface IValidator
    {
        Task<GenericResponse<string>> ValidateCategoryToAdd(CategoryToAdd category);
        Task<GenericResponse<string>> ValidateClientToAdd(ClientToAdd clientToAdd);
        Task<GenericResponse<string>> ValidateProductToAdd(ProductToAdd productToAdd);
        Task<GenericResponse<string>> ValidateProductToUpdate(ProductToUpdate productToUpdate);
    }
}