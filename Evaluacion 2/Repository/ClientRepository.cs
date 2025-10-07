using System.Linq;
using Evaluacion_2.Models;
using Evaluacion_2.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Evaluacion_2.Repository;

public class ClientRepository : IClientRepository
{
    private readonly AppDbContext _context;

    public ClientRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Client>> GetClientsByNameAsync(string name)
    {
        return await _context.Clients
            .Where(c => c.Name.Contains(name))
            .ToListAsync();
    }

    public async Task<IEnumerable<ClientOrderCount>> GetClientsWithMostOrdersAsync()
    {
        // First, get the maximum number of orders any client has
        var maxOrders = await _context.Clients
            .Select(c => c.Orders.Count)
            .MaxAsync();

        // Then, get all clients that have that number of orders
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