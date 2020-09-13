using DroneDelivery.PedidoConsumerTrigger.Model;
using System.Threading.Tasks;

namespace DroneDelivery.PedidoConsumerTrigger.Contrato
{
    public interface ICommand
    {
        Task<bool> PedidoAsync( PedidoCriadoEvent @event);
    }
}
