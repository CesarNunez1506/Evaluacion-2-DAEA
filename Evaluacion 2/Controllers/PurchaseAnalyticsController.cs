using Microsoft.AspNetCore.Mvc;
using Evaluacion_2.Repository.Interface;

namespace Evaluacion_2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PurchaseAnalyticsController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public PurchaseAnalyticsController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    /// <summary>
    /// Ejercicio 11: Obtener Todos los Productos Vendidos por un Cliente Específico
    /// </summary>
    /// <param name="clientId">ID del cliente</param>
    /// <returns>Lista de productos vendidos al cliente</returns>
    [HttpGet("products-by-client/{clientId}")]
    public async Task<IActionResult> GetProductsSoldToClient(int clientId)
    {
        var products = await _unitOfWork.OrderRepository.GetProductsSoldToClientAsync(clientId);
        return Ok(products);
    }

    /// <summary>
    /// Ejercicio 12: Obtener Todos los Clientes que Han Comprado un Producto Específico
    /// </summary>
    /// <param name="productId">ID del producto</param>
    /// <returns>Lista de clientes que han comprado el producto</returns>
    [HttpGet("clients-by-product/{productId}")]
    public async Task<IActionResult> GetClientsWhoPurchasedProduct(int productId)
    {
        var clients = await _unitOfWork.OrderRepository.GetClientsWhoPurchasedProductAsync(productId);
        return Ok(clients);
    }
}