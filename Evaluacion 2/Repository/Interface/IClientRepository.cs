using System.Threading.Tasks;
using System.Collections.Generic;
using Evaluacion_2.Models;

namespace Evaluacion_2.Repository.Interface;

public record ClientOrderCount(int ClientId, string ClientName, int OrderCount);

public interface IClientRepository
{
    Task<IEnumerable<Client>> GetClientsByNameAsync(string name);
    Task<ClientOrderCount> GetClientWithMostOrdersAsync();
}