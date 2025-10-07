using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Evaluacion_2.Models;

namespace Evaluacion_2.Repository.Interface;

public interface IOrderRepository
{
    Task<IEnumerable<OrderDetailDto>> GetOrderDetailsAsync(int orderId);
    Task<int> GetTotalProductsInOrderAsync(int orderId);
    Task<IEnumerable<Order>> GetOrdersAfterDateAsync(DateTime date);
    Task<IEnumerable<OrderDetailDto>> GetAllOrderDetailsAsync();
    Task<IEnumerable<ProductSoldDto>> GetProductsSoldToClientAsync(int clientId);
    Task<IEnumerable<Client>> GetClientsWhoPurchasedProductAsync(int productId);
}