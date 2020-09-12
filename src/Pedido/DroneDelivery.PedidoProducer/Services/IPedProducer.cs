using DroneDelivery.PedidoProducer.Dto;
using System.Threading.Tasks;

namespace DroneDelivery.PedidoProducer.Services
{
    public interface IPedProducer
    {
        Task EnviarPedido(CriarPedidoDto pedidoDto);
    }
}
