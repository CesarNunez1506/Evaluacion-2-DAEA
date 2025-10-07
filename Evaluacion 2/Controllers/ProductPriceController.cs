using Microsoft.AspNetCore.Mvc;
using Evaluacion_2.Repository.Interface;

namespace Evaluacion_2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductPriceController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductPriceController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    /// <summary>
    /// Ejercicio 2: Obtener los Productos con Precio Mayor a un Valor Específico
    /// </summary>
    /// <param name="minPrice">Precio mínimo para filtrar los productos</param>
    /// <returns>Lista de productos con precio mayor al especificado</returns>
    [HttpGet]
    public async Task<IActionResult> GetProductsByPrice([FromQuery] decimal minPrice)
    {
        var products = await _unitOfWork.ProductRepository.GetProductsByPriceAsync(minPrice);
        return Ok(products);
    }

    /// <summary>
    /// Ejercicio 5: Obtener el Producto Más Caro
    /// </summary>
    [HttpGet("most-expensive")]
    public async Task<IActionResult> GetMostExpensiveProduct()
    {
        var product = await _unitOfWork.ProductRepository.GetMostExpensiveProductAsync();
        return Ok(product);
    }

    /// <summary>
    /// Ejercicio 7: Obtener el Promedio de Precio de los Productos
    /// </summary>
    [HttpGet("average-price")]
    public async Task<IActionResult> GetAveragePrice()
    {
        var averagePrice = await _unitOfWork.ProductRepository.GetAveragePriceAsync();
        return Ok(new { AveragePrice = averagePrice });
    }

    /// <summary>
    /// Ejercicio 8: Obtener Todos los Productos que No Tienen Descripción
    /// </summary>
    [HttpGet("without-description")]
    public async Task<IActionResult> GetProductsWithoutDescription()
    {
        var products = await _unitOfWork.ProductRepository.GetProductsWithoutDescriptionAsync();
        return Ok(products);
    }
}