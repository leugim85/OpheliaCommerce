using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OpheliaCommerce.App.Validators;
using OpheliaCommerce.Data.Context;
using OpheliaCommerce.Domain.Dtos;
using OpheliaCommerce.Domain.Entities;
using OpheliaCommerce.Domain.Infrastructure.Utilities;
using OpheliaCommerce.Domain.Models;

namespace OpheliaCommerce.App.Services
{
    public class ProductService : IProductService
    {
        private readonly EcommerceContext context;
        private readonly IMapper mapper;
        private readonly IValidator validator;

        public ProductService(EcommerceContext context, IMapper mapper, IValidator validator)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.validator = validator ?? throw new ArgumentNullException(nameof(validator));
        }

        public async Task<List<ProductDto>> GetProducts()
        {
            var result = await context.Products.ToListAsync();
            var productsList = mapper.Map<List<ProductDto>>(result);

            return productsList;
        }

        public async Task<ProductDto> GetProductById(int id)
        {
            var product = await context.Products.FirstOrDefaultAsync(c => c.Id == id);
            var productDto = mapper.Map<ProductDto>(product);
            return productDto;
        }

        public async Task<GenericResponse<string>> CreateProduct(ProductToAdd productToAdd)
        {
            var isValid = await validator.ValidateProductToAdd(productToAdd);
            if (!isValid.IsSucces)
                return new GenericResponse<string>(false, isValid.Message);

            var product = mapper.Map<Product>(productToAdd);
            context.Products.Add(product);
            await context.SaveChangesAsync();

            return new GenericResponse<string>();
        }

        public async Task<GenericResponse<string>> DeleteProduct(int id)
        {
            var product = await context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
                return new GenericResponse<string>(false, "El producto no se ha encontrado");

            context.Products.Remove(product);
            await context.SaveChangesAsync();
            return new GenericResponse<string>();
        }

        public async Task<GenericResponse<string>> UpdateProduct(ProductToUpdate productToUpdate)
        {
            var isValid = await validator.ValidateProductToUpdate(productToUpdate);
            if (!isValid.IsSucces)
                return new GenericResponse<string>(false, isValid.Message);

            var product = await context.Products.FirstOrDefaultAsync(p => p.Id == productToUpdate.Id);
            if (product is null)
                return new GenericResponse<string>(false, "El producto que intenta actualizar no se ha encontrado");

            product.Stock = productToUpdate.Stock;
            product.Price = productToUpdate.Price;
            product.Description = productToUpdate.Description;
            product.CategoryId = productToUpdate.CategoryId;
            product.Name = productToUpdate.Name;

            context.Products.Update(product);
            await context.SaveChangesAsync();

            return new GenericResponse<string>();
        }

        public async Task<GenericResponse<string>> UpdateProductStock(List<ProductToShopping> productToshoppingList)
        {
            foreach (var productToShopping in productToshoppingList) 
            {
                var product = await context.Products.FirstOrDefaultAsync(p => p.Id == productToShopping.Id);
                if (product is null)
                    return new GenericResponse<string>(false, "El producto que intenta actualizar no se ha encontrado");

                product.Stock = product.Stock - productToShopping.Quantity;
                await context.SaveChangesAsync();
            }
                return new GenericResponse<string>();
        }
    }
}
