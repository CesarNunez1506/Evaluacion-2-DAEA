using Evaluacion_2.Models;

namespace Evaluacion_2.Repository.interfaces;

public interface IClientRepository
{
    Task<IEnumerable<Client>> GetClientsByNameAsync(string name);
}