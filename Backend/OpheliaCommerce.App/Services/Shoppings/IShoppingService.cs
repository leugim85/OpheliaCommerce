using OpheliaCommerce.Domain.Dtos;
using OpheliaCommerce.Domain.Infrastructure.Utilities;
using OpheliaCommerce.Domain.Models;

namespace OpheliaCommerce.App.Services
{
    public interface IShoppingService
    {
        Task<GenericResponse<string>> AddShopping(ShoppingRequest shoppingRequest);
        Task<ClientShoppingsDto> GetShoppingInfoByClient(int ClientId);
    }
}