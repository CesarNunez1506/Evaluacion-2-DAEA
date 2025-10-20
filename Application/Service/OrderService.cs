using Application.DTO;
using Domain.Interface;
using Domain.Entities;

namespace Application.Service
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
