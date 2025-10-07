using Evaluacion_2.Models;

namespace Evaluacion_2.Repository;

public interface IOrderRepository
{
    Task<IEnumerable<OrderDetailDto>> GetOrderDetailsAsync(int orderId);
    Task<int> GetTotalProductsInOrderAsync(int orderId);
}

public class OrderDetailDto
{
    public string ProductName { get; set; } = string.Empty;
    public int Quantity { get; set; }
}