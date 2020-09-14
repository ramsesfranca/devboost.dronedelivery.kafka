using System.Threading.Tasks;

namespace DroneDelivery.PedidoConsumerTrigger.Contrato
{
    public interface IUsuarioAutenticacao
    {
        Task<string> GetToken();
    }
}