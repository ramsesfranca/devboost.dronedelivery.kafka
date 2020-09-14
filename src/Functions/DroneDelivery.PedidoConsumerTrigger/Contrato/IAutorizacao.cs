using System.Threading.Tasks;

namespace DroneDelivery.PedidoConsumerTrigger.Contrato
{
    public interface IAutorizacao
    {
        Task<string> GetToken();
    }
}