using Evaluacion_2.Models;
using Evaluacion_2.Repository.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
using Evaluacion_2.Models.DTO;

namespace Evaluacion_2.Service
{
    public interface IOrderService
    {
        Task<IEnumerable<ProductSoldDto>> GetProductsSoldToClientAsync(int clientId);
        Task<IEnumerable<Client>> GetClientsWhoPurchasedProductAsync(int productId);
    }

    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IEnumerable<ProductSoldDto>> GetProductsSoldToClientAsync(int clientId)
        {
            return await _orderRepository.GetProductsSoldToClientAsync(clientId);
        }

        public async Task<IEnumerable<Client>> GetClientsWhoPurchasedProductAsync(int productId)
        {
            return await _orderRepository.GetClientsWhoPurchasedProductAsync(productId);
        }
    }
}
