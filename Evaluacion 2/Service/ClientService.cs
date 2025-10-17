using Evaluacion_2.Models;
using Evaluacion_2.Models.DTO;
using Evaluacion_2.Repository.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Evaluacion_2.Service
{
    public interface IClientService
    {
        Task<IEnumerable<ClientDto>> GetClientsByNameAsync(string name);
        Task<IEnumerable<ClientOrderCount>> GetClientsWithMostOrdersAsync();
        Task<IEnumerable<ClientOrderDto>> GetClientsWithOrdersAsDtoAsync();
    }

    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<IEnumerable<ClientDto>> GetClientsByNameAsync(string name)
        {
            var clients = await _clientRepository.GetClientsByNameAsync(name);
            return clients.Select(c => new ClientDto
            {
                ClientId = c.ClientId,
                Name = c.Name,
                Email = c.Email
            });
        }

        public async Task<IEnumerable<ClientOrderCount>> GetClientsWithMostOrdersAsync()
        {
            return await _clientRepository.GetClientsWithMostOrdersAsync();
        }

        public async Task<IEnumerable<ClientOrderDto>> GetClientsWithOrdersAsDtoAsync()
        {
            return await _clientRepository.GetClientsWithOrdersAsDtoAsync();
        }
    }
}
