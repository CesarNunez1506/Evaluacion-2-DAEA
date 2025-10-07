using Microsoft.AspNetCore.Mvc;
using Evaluacion_2.Repository.interfaces;

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
}