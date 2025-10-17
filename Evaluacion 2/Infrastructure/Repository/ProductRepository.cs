using System.Collections.Generic;
using System.Threading.Tasks;
using Evaluacion_2.Models;
using Evaluacion_2.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Evaluacion_2.Repository;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetProductsByPriceAsync(decimal minPrice)
    {
        return await _context.Products
            .Where(p => p.Price > minPrice)
            .ToListAsync();
    }

    public async Task<Product?> GetMostExpensiveProductAsync()
    {
        return await _context.Products
            .OrderByDescending(p => p.Price)
            .FirstOrDefaultAsync();
    }

    public async Task<decimal> GetAveragePriceAsync()
    {
        return await _context.Products
            .Select(p => p.Price)
            .AverageAsync();
    }

    public async Task<IEnumerable<Product>> GetProductsWithoutDescriptionAsync()
    {
        return await _context.Products
            .Where(p => string.IsNullOrEmpty(p.Description))
            .ToListAsync();
    }
}