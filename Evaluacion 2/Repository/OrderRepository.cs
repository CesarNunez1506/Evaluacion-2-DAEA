using Evaluacion_2.Models;
using Microsoft.EntityFrameworkCore;

namespace Evaluacion_2.Repository;

public class OrderRepository : IOrderRepository
{
    private readonly AppDbContext _context;

    public OrderRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<OrderDetailDto>> GetOrderDetailsAsync(int orderId)
    {
        return await _context.Orderdetails
            .Where(od => od.OrderId == orderId)
            .Select(od => new OrderDetailDto
            {
                ProductName = od.Product.Name,
                Quantity = od.Quantity
            })
            .ToListAsync();
    }

    public async Task<int> GetTotalProductsInOrderAsync(int orderId)
    {
        return await _context.Orderdetails
            .Where(od => od.OrderId == orderId)
            .SumAsync(od => od.Quantity);
    }
}