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
    }
}