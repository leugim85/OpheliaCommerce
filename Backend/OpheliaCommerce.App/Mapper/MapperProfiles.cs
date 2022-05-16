using AutoMapper;
using OpheliaCommerce.App.Services;
using OpheliaCommerce.Domain.Dtos;
using OpheliaCommerce.Domain.Entities;
using OpheliaCommerce.Domain.Models;

namespace OpheliaCommerce.App.Mapper
{
    public class MapperProfiles: Profile
    {
        public MapperProfiles()
        {
            CreateMap<CategoryToAdd, Category>();
            CreateMap<Category, CategoryDto>();

            CreateMap<ClientToAdd, Client>();
            CreateMap<Client, ClientDto>();

            CreateMap<Product, ProductDto>();
            CreateMap<ProductToAdd, Product>();
        }
    }
}
