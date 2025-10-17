using System.Collections.Generic;
using System.Threading.Tasks;
using Evaluacion_2.Models;

namespace Evaluacion_2.Repository.Interface;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetProductsByPriceAsync(decimal minPrice);
    Task<Product?> GetMostExpensiveProductAsync();
    Task<decimal> GetAveragePriceAsync();
    Task<IEnumerable<Product>> GetProductsWithoutDescriptionAsync();
}