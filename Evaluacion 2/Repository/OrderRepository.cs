using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Evaluacion_2.Models;
using Evaluacion_2.Repository.Interface;
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

    public async Task<IEnumerable<Order>> GetOrdersAfterDateAsync(DateTime date)
    {
        return await _context.Orders
            .Where(o => o.OrderDate > date)
            .ToListAsync();
    }

    public async Task<IEnumerable<OrderDetailDto>> GetAllOrderDetailsAsync()
    {
        return await _context.Orderdetails
            .Select(od => new OrderDetailDto
            {
                ProductName = od.Product.Name,
                Quantity = od.Quantity
            })
            .ToListAsync();
    }

    public async Task<IEnumerable<ProductSoldDto>> GetProductsSoldToClientAsync(int clientId)
    {
        return await _context.Orders
            .Where(o => o.ClientId == clientId)
            .SelectMany(o => o.Orderdetails)
            .Select(od => new ProductSoldDto
            {
                ProductName = od.Product.Name,
                Price = od.Product.Price,
                Quantity = od.Quantity,
                OrderDate = od.Order.OrderDate
            })
            .ToListAsync();
    }

    public async Task<IEnumerable<Client>> GetClientsWhoPurchasedProductAsync(int productId)
    {
        return await _context.Orderdetails
            .Where(od => od.ProductId == productId)
            .Select(od => od.Order.Client)
            .Distinct()
            .ToListAsync();
    }
}