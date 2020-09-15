using DroneDelivery.PedidoConsumerTrigger.Model;
using System.Threading.Tasks;

namespace DroneDelivery.PedidoConsumerTrigger.Contrato
{
    public interface IPagamentoCommand
    {
        Task<bool> PagamentoAsync(PagamentoCriadoEvent @event);
    }
}
