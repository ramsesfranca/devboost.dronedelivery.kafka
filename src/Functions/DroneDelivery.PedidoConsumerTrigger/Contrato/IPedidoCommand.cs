using DroneDelivery.PedidoConsumerTrigger.Model;
using System.Threading.Tasks;

namespace DroneDelivery.PedidoConsumerTrigger.Contrato
{
    public interface IPedidoCommand
    {
        Task<bool> PedidoAsync( PedidoCriadoEvent @event);
    }
}
