using Microsoft.EntityFrameworkCore;
using OpheliaCommerce.Data.Context;
using OpheliaCommerce.Domain.Dtos;
using OpheliaCommerce.Domain.Entities;
using OpheliaCommerce.Domain.Infrastructure.Utilities;
using OpheliaCommerce.Domain.Models;

namespace OpheliaCommerce.App.Services
{
    public class ShoppingService : IShoppingService
    {
        private readonly EcommerceContext context;
        private readonly IProductService productService;
        private readonly IClientService clientService;

        public ShoppingService(EcommerceContext context, IProductService productService, IClientService clientService)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.productService = productService ?? throw new ArgumentNullException(nameof(productService));
            this.clientService = clientService ?? throw new ArgumentNullException(nameof(clientService));
        }

        public async Task<GenericResponse<string>> AddShopping(ShoppingRequest shoppingRequest)
        {
            var productsByClient = shoppingRequest.Products;
            if (!productsByClient.Any())
                return new GenericResponse<string>(false, "Se deben ingresar productos para realizar la transacción");

            var validClient = await context.Clients.FirstOrDefaultAsync(c => c.Id == shoppingRequest.CLientId);
            if (validClient is null)
                return new GenericResponse<string>(false, "El cliente no se enuentra registrado");

            var products = new List<ProductBasicInfo>();

            foreach (var product in productsByClient)
            {
                var productInfo = new ProductBasicInfo();

                var validProduct = await context.Products.FirstOrDefaultAsync(p => p.Id == product.Id);
                if (validProduct is null)
                    return new GenericResponse<string>(false, $"No se ha encontrado el producto con el id {product.Id}");

                var validStock = validProduct.Stock >= product.Quantity;
                if (!validStock)
                    return new GenericResponse<string>(false, $"La cantidad solicitada del producto {validProduct.Name} es superior al stock actual que es de {validProduct.Stock}");

                productInfo.Quantity = product.Quantity;
                productInfo.Price = validProduct.Price;
                productInfo.Id = validProduct.Id;

                products.Add(productInfo);
            }

            var headerPayment = new Shopping
            {
                ClientId = validClient.Id,
                Date = shoppingRequest.Date,
                TotalPay = (products.Sum(item => (item.Price * item.Quantity))),
                ShoppingDetails = products.Select(c => new ShoppingDetails
                {
                    Price = c.Price,
                    Quantity = c.Quantity,
                    ProductId = c.Id
                }).ToList()
            };

            context.Shoppings.Add(headerPayment);
            await productService.UpdateProductStock(productsByClient);
            await context.SaveChangesAsync();
            return new GenericResponse<string>();
        }

        public async Task<ClientShoppingsDto> GetShoppingInfoByClient(int ClientId)
        {
            var shopping = await context
                .Shoppings
                .Include(c => c.ShoppingDetails)
                .ThenInclude(c => c.Product)
                .FirstOrDefaultAsync(c => c.ClientId == ClientId);
            if (shopping is null)
                return null;
            var client = await clientService.GetClientById(ClientId);
            var infoShoppingDto = new ClientShoppingsDto
            {

                Client = client.Name,
                Date = shopping.Date,
                TotalAmount = shopping.TotalPay,
                ShoppingDetails = shopping.ShoppingDetails.Select(c => new ShoppingDetailsDto
                {
                    ProductId = c.ProductId,
                    ProductName = c.Product.Name,
                    Price = c.Price,
                    Quantity = c.Quantity
                }).ToList()
            };
            return infoShoppingDto;
        }

    }
}

