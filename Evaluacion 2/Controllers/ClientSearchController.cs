using Microsoft.AspNetCore.Mvc;
using Evaluacion_2.Service;

namespace Evaluacion_2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientSearchController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientSearchController(IClientService clientService)
        {
            _clientService = clientService;
        }

        /// <summary>
        /// Obtener clientes y sus pedidos como DTO (solo lectura, AsNoTracking)
        /// </summary>
        [HttpGet("with-orders")]
        public async Task<IActionResult> GetClientsWithOrders()
        {
            var clientOrders = await _clientService.GetClientsWithOrdersAsDtoAsync();
            return Ok(clientOrders);
        }

        /// <summary>
        /// Ejercicio 1: Obtener los Clientes que Tienen un Nombre Específico
        /// </summary>
        /// <param name="name">Nombre o parte del nombre a buscar</param>
        /// <returns>Lista de clientes que coinciden con el nombre</returns>
        [HttpGet]
        public async Task<IActionResult> GetClientsByName([FromQuery] string name)
        {
            var clients = await _clientService.GetClientsByNameAsync(name);
            return Ok(clients);
        }

        /// <summary>
        /// Ejercicio 9: Obtener los Clientes con Mayor Número de Pedidos
        /// </summary>
        [HttpGet("most-orders")]
        public async Task<IActionResult> GetClientsWithMostOrders()
        {
            var clientOrderCounts = await _clientService.GetClientsWithMostOrdersAsync();
            return Ok(clientOrderCounts);
        }
    }
}