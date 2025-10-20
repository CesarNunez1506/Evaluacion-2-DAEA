using Application.DTO;
using Domain.Entities;

namespace Domain.Interface;

public interface IOrderRepository
{
    Task<IEnumerable<OrderDetailDto>> GetOrderDetailsAsync(int orderId);
    Task<int> GetTotalProductsInOrderAsync(int orderId);
    Task<IEnumerable<Order>> GetOrdersAfterDateAsync(DateTime date);
    Task<IEnumerable<OrderDetailDto>> GetAllOrderDetailsAsync();
    Task<IEnumerable<ProductSoldDto>> GetProductsSoldToClientAsync(int clientId);
    Task<IEnumerable<Client>> GetClientsWhoPurchasedProductAsync(int productId);
    Task<IEnumerable<OrderDetailsDto>> GetOrdersWithDetailsAsDtoAsync();
}