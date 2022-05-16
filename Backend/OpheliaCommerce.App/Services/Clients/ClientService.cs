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
    public class ClientService : IClientService
    {
        private readonly EcommerceContext context;
        private readonly IMapper mapper;
        private readonly IValidator validator;

        public ClientService(EcommerceContext context, IMapper mapper, IValidator validator)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.validator = validator ?? throw new ArgumentNullException(nameof(validator));
        }

        public async Task<GenericResponse<Client>> AddClient(ClientToAdd clientToAdd)
        {
            var isValid = await validator.ValidateClientToAdd(clientToAdd);
            if (!isValid.IsSucces)
                return new GenericResponse<Client>(false, isValid.Message);

            var client = mapper.Map<Client>(clientToAdd);
            context.Clients.Add(client);
            await context.SaveChangesAsync();

            return new GenericResponse<Client>(true, client);
        }

        public async Task<List<ClientDto>> GetAllClients()
        {
            var result = await context.Clients.ToListAsync();
            var clientsList = mapper.Map<List<ClientDto>>(result);
            return clientsList;
        }

        public async Task<ClientDetailsDto> GetClientById(int id)
        {
            var client = await context.Clients.Include(c => c.ShoppingList).ThenInclude(s => s.ShoppingDetails).ThenInclude(d => d.Product).FirstOrDefaultAsync(c => c.Id == id);
            if (client is null)
                return null;

            double value = 0;
            foreach (var shopping in client.ShoppingList)
            {
                value = value + shopping.TotalPay;
            }

            ClientDetailsDto clientDetails = new ClientDetailsDto
            {
                Id = id,
                Name = client.Name,
                Email = client.Email,
                TotalSpend = value,
  
                Shoppings = client.ShoppingList.Select(c => new ShoppingDto
                {
                    Id = c.Id,
                    Date = c.Date,
                    PayValue = c.TotalPay,
                    Products = c.ShoppingDetails.Select(c => new ProductDto
                    {
                        Id = c.ProductId,
                        Price = c.Price,
                        Name = c.Product.Name,
                        Description = c.Product.Description,
                        Quantity = c.Quantity
                    }).ToList()
                }).ToList()  
            };

            return clientDetails;
        }

        public async Task<GenericResponse<string>> DeleteClientById(int id)
        {
            var client = await context.Clients.FirstOrDefaultAsync(c => c.Id == id);
            if (client is null)
                return new GenericResponse<string>(false, "El cliente que desea eliminar no ha sido encontrado");

            context.Clients.Remove(client);
            await context.SaveChangesAsync();

            return new GenericResponse<string>();
        }
    }
}
