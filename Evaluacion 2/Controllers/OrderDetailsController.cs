using Microsoft.AspNetCore.Mvc;
using Evaluacion_2.Repository.interfaces;

namespace Evaluacion_2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderDetailsController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public OrderDetailsController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    /// <summary>
    /// Ejercicio 3: Obtener el Detalle de los Productos en una Orden
    /// </summary>
    /// <param name="orderId">ID de la orden</param>
    /// <returns>Lista de detalles de productos en la orden</returns>
    [HttpGet("{orderId}/products")]
    public async Task<IActionResult> GetOrderDetails(int orderId)
    {
        var details = await _unitOfWork.OrderRepository.GetOrderDetailsAsync(orderId);
        return Ok(details);
    }

    /// <summary>
    /// Ejercicio 4: Obtener la Cantidad Total de Productos por Orden
    /// </summary>
    /// <param name="orderId">ID de la orden</param>
    /// <returns>Cantidad total de productos en la orden</returns>
    [HttpGet("{orderId}/total-products")]
    public async Task<IActionResult> GetTotalProductsInOrder(int orderId)
    {
        var total = await _unitOfWork.OrderRepository.GetTotalProductsInOrderAsync(orderId);
        return Ok(new { TotalProducts = total });
    }
}