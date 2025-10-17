using Application.DTO;

namespace Application.Service
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProductsByPriceAsync(decimal minPrice);
        Task<ProductDto?> GetMostExpensiveProductAsync();
        Task<decimal> GetAveragePriceAsync();
        Task<IEnumerable<ProductDto>> GetProductsWithoutDescriptionAsync();
    }

    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductDto>> GetProductsByPriceAsync(decimal minPrice)
        {
            var products = await _productRepository.GetProductsByPriceAsync(minPrice);
            return products.Select(p => new ProductDto
            {
                ProductId = p.ProductId,
                Name = p.Name,
                Price = p.Price,
                Description = p.Description
            });
        }

        public async Task<ProductDto?> GetMostExpensiveProductAsync()
        {
            var product = await _productRepository.GetMostExpensiveProductAsync();
            if (product == null) return null;
            return new ProductDto
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description
            };
        }

        public async Task<decimal> GetAveragePriceAsync()
        {
            return await _productRepository.GetAveragePriceAsync();
        }

        public async Task<IEnumerable<ProductDto>> GetProductsWithoutDescriptionAsync()
        {
            var products = await _productRepository.GetProductsWithoutDescriptionAsync();
            return products.Select(p => new ProductDto
            {
                ProductId = p.ProductId,
                Name = p.Name,
                Price = p.Price,
                Description = p.Description
            });
        }
    }
}
