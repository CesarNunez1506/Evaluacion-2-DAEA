using Microsoft.AspNetCore.Mvc;
using Evaluacion_2.Repository;

namespace Evaluacion_2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExercisesController : ControllerBase
{
    private readonly IClientRepository _clientRepository;
    private readonly IProductRepository _productRepository;
    private readonly IOrderRepository _orderRepository;

    public ExercisesController(
        IClientRepository clientRepository,
        IProductRepository productRepository,
        IOrderRepository orderRepository)
    {
        _clientRepository = clientRepository;
        _productRepository = productRepository;
        _orderRepository = orderRepository;
    }

    // Ejercicio 1: Obtener los Clientes que Tienen un Nombre Específico
    [HttpGet("clients")]
    public async Task<IActionResult> GetClientsByName([FromQuery] string name)
    {
        var clients = await _clientRepository.GetClientsByNameAsync(name);
        return Ok(clients);
    }

    // Ejercicio 2: Obtener los Productos con Precio Mayor a un Valor Específico
    [HttpGet("products")]
    public async Task<IActionResult> GetProductsByPrice([FromQuery] decimal minPrice)
    {
        var products = await _productRepository.GetProductsByPriceAsync(minPrice);
        return Ok(products);
    }

    // Ejercicio 3: Obtener el Detalle de los Productos en una Orden
    [HttpGet("orders/{orderId}/details")]
    public async Task<IActionResult> GetOrderDetails(int orderId)
    {
        var details = await _orderRepository.GetOrderDetailsAsync(orderId);
        return Ok(details);
    }

    // Ejercicio 4: Obtener la Cantidad Total de Productos por Orden
    [HttpGet("orders/{orderId}/total-products")]
    public async Task<IActionResult> GetTotalProductsInOrder(int orderId)
    {
        var total = await _orderRepository.GetTotalProductsInOrderAsync(orderId);
        return Ok(new { TotalProducts = total });
    }
}