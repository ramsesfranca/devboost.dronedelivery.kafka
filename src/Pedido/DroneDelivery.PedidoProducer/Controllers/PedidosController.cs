using DroneDelivery.PedidoProducer.Dto;
using DroneDelivery.PedidoProducer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DroneDelivery.PedidoProducer.Controllers
{
    [Route("api/[controller]")]
    public class PedidosController : ControllerBase
    {
        private readonly IPedProducer _pedidoProducer;

        public PedidosController(IPedProducer pedidoProducer)
        {
            _pedidoProducer = pedidoProducer;
        }

        /// <summary>
        /// Criar um pedido
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/pedidos
        ///     {
        ///        "peso": 10000,
        ///        "valor": 999
        ///     }
        ///
        /// </remarks>        
        /// <param name="pedidoDto"></param>  
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Adicionar([FromBody] CriarPedidoDto pedidoDto)
        {
            await _pedidoProducer.EnviarPedido(pedidoDto);
            return Ok();
        }
    }
}
