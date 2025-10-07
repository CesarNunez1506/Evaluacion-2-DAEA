using Microsoft.AspNetCore.Mvc;
using Evaluacion_2.Repository.Interface;

namespace Evaluacion_2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientSearchController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public ClientSearchController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    /// <summary>
    /// Ejercicio 1: Obtener los Clientes que Tienen un Nombre Específico
    /// </summary>
    /// <param name="name">Nombre o parte del nombre a buscar</param>
    /// <returns>Lista de clientes que coinciden con el nombre</returns>
    [HttpGet]
    public async Task<IActionResult> GetClientsByName([FromQuery] string name)
    {
        var clients = await _unitOfWork.ClientRepository.GetClientsByNameAsync(name);
        return Ok(clients);
    }

    /// <summary>
    /// Ejercicio 9: Obtener los Clientes con Mayor Número de Pedidos
    /// </summary>
    [HttpGet("most-orders")]
    public async Task<IActionResult> GetClientsWithMostOrders()
    {
        var clients = await _unitOfWork.ClientRepository.GetClientsWithMostOrdersAsync();
        return Ok(clients);
    }
}