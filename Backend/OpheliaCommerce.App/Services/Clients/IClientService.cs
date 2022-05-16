using OpheliaCommerce.Domain.Dtos;
using OpheliaCommerce.Domain.Entities;
using OpheliaCommerce.Domain.Infrastructure.Utilities;
using OpheliaCommerce.Domain.Models;

namespace OpheliaCommerce.App.Services
{
    public interface IClientService
    {
        Task<GenericResponse<Client>> AddClient(ClientToAdd clientToAdd);
        Task<GenericResponse<string>> DeleteClientById(int id);
        Task<List<ClientDto>> GetAllClients();
        Task<ClientDetailsDto> GetClientById(int id);
    }
}