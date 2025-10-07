using Evaluacion_2.Models;

namespace Evaluacion_2.Repository.interfaces;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetProductsByPriceAsync(decimal minPrice);
}