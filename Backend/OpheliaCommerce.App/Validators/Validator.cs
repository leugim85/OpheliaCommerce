using Microsoft.EntityFrameworkCore;
using OpheliaCommerce.App.Services;
using OpheliaCommerce.Data.Context;
using OpheliaCommerce.Domain.Infrastructure.ExtensionMethods;
using OpheliaCommerce.Domain.Infrastructure.Utilities;
using OpheliaCommerce.Domain.Models;

namespace OpheliaCommerce.App.Validators
{
    public class Validator : IValidator
    {
        private readonly EcommerceContext context;

        public Validator(EcommerceContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<GenericResponse<string>> ValidateCategoryToAdd(CategoryToAdd category)
        {
            if (category.Name == String.Empty || category.Description == String.Empty)
                return new GenericResponse<string>(false, "Todos los campos son obligatorios!");

            var exists = await context.Categories.AnyAsync(c => c.Name.ToLower() == category.Name.ToLower());
            if (exists)
                return new GenericResponse<string>(false, "La nombre categoria que intenta ingresar se encuentra en uso");

            return new GenericResponse<string>();
        }

        public async Task<GenericResponse<string>> ValidateClientToAdd(ClientToAdd clientToAdd)
        {
            if (clientToAdd.Email == String.Empty || clientToAdd.Name == String.Empty)
                return new GenericResponse<string>(false, "Todos los campos son requeridos!");

            if (!clientToAdd.Email.IsValidEmail())
                return new GenericResponse<string>(false, "El correo no tiene un formato valido");

            var exists = await context.Clients.Where(c => c.Email.ToLower() == clientToAdd.Email.ToLower()).ToListAsync();
            if (exists.Any())
                return new GenericResponse<string>(false, $"El correo {clientToAdd.Email} ya se encuentra registrado");

            return new GenericResponse<string>();
        }

        public async Task<GenericResponse<string>> ValidateProductToAdd(ProductToAdd productToAdd)
        {
            if (productToAdd.Name == string.Empty || productToAdd.Description == string.Empty)
                return new GenericResponse<string>(false, "Debe ingresar todos los campos!");

            if (productToAdd.Stock < 0)
                return new GenericResponse<string>(false, "La cantidad en stock no puede ser inferior a 0");

            if (productToAdd.Price < 1)
                return new GenericResponse<string>(false, "El precio no puede ser menor a 1");

            var exists = await context.Products.Where(p => p.Name.ToLower() == productToAdd.Name.ToLower()).ToListAsync();
            if (exists.Any())
                return new GenericResponse<string>(false, $"El producto con el nombre {productToAdd.Name} ya se encuentra registrado");

            var validCategory = await context.Categories.FirstOrDefaultAsync(c => c.Id == productToAdd.CategoryId);
            if (validCategory is null || !validCategory.IsActive)
                return new GenericResponse<string>(false, "La categoria ingresada no es valida o se encuentra inactiva");

            return new GenericResponse<string>();
        }

        public async Task<GenericResponse<string>> ValidateProductToUpdate(ProductToUpdate productToUpdate)
        {
            if (productToUpdate.Description == string.Empty)
                return new GenericResponse<string>(false, "Debe ingresar todos los campos!");

            if (productToUpdate.Stock < 0)
                return new GenericResponse<string>(false, "La cantidad en stock no puede ser inferior a 0");

            if (productToUpdate.Price < 1)
                return new GenericResponse<string>(false, "El precio no puede ser menor a 1");

            var inValidName = await context.Products.AnyAsync(p => p.Name.Equals(productToUpdate.Name) && p.Id != productToUpdate.Id);
            if (inValidName)
                return new GenericResponse<string>(false, "El nombre del producto ya se encuentra en uso");


            var validCategory = await context.Categories.FirstOrDefaultAsync(c => c.Id == productToUpdate.CategoryId);
            if (validCategory is null || !validCategory.IsActive)
                return new GenericResponse<string>(false, "La categoria ingresada no es valida o se encuentra inactiva");

            return new GenericResponse<string>();
        }
    }
}

