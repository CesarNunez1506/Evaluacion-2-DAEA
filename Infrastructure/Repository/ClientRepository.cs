using Application.DTO;
using Domain.Entities;
using Domain.Interface;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly AppDbContext _context;

        public ClientRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ClientOrderDto>> GetClientsWithOrdersAsDtoAsync()
        {
            return await _context.Clients
                .AsNoTracking()
                .Include(c => c.Orders)
                .Select(client => new ClientOrderDto
                {
                    ClientName = client.Name,
                    Orders = client.Orders
                        .Select(order => new OrderDto
                        {
                            OrderId = order.OrderId,
                            OrderDate = order.OrderDate
                        }).ToList()
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<Client>> GetClientsByNameAsync(string name)
        {
            return await _context.Clients
                .Where(c => c.Name.Contains(name))
                .ToListAsync();
        }

        public async Task<IEnumerable<ClientOrderCount>> GetClientsWithMostOrdersAsync()
        {
            var maxOrders = await _context.Clients
                .Select(c => c.Orders.Count)
                .MaxAsync();
            var clientsWithMostOrders = await _context.Clients
                .Where(c => c.Orders.Count == maxOrders)
                .Select(c => new ClientOrderCount(
                    c.ClientId,
                    c.Name,
                    c.Orders.Count))
                .ToListAsync();

            return clientsWithMostOrders;
        }

        public async Task<IEnumerable<ClientProductTotal>> GetClientsWithTotalProductsAsync()
        {
            return await _context.Clients
                .AsNoTracking()
                .Select(client => new ClientProductTotal
                {
                    ClientId = client.ClientId,
                    ClientName = client.Name,
                    TotalProducts = client.Orders
                        .Select(order => order.Orderdetails.Sum(od => od.Quantity))
                        .Sum()
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<SalesByClientDto>> GetSalesByClientAsync()
        {
            var sales = await _context.Orders
                .Include(order => order.Orderdetails)
                .ThenInclude(od => od.Product)
                .AsNoTracking()
                .GroupBy(order => order.ClientId)
                .Select(group => new SalesByClientDto
                {
                    ClientName = _context.Clients.FirstOrDefault(c => c.ClientId == group.Key)!.Name,
                    TotalSales = group.Sum(order => order.Orderdetails.Sum(detail => detail.Quantity * detail.Product.Price))
                })
                .OrderByDescending(s => s.TotalSales)
                .ToListAsync();

            return sales;
        }
    }
}