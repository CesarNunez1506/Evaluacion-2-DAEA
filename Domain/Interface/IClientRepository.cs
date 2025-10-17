using Application.DTO;
using Domain.Entities;

namespace Domain.Interface;

public record ClientOrderCount(int ClientId, string ClientName, int OrderCount);

public interface IClientRepository
{
    Task<IEnumerable<Client>> GetClientsByNameAsync(string name);
    Task<IEnumerable<ClientOrderCount>> GetClientsWithMostOrdersAsync();
    Task<IEnumerable<ClientOrderDto>> GetClientsWithOrdersAsDtoAsync();
}