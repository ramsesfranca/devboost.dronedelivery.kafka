using DroneDelivery.PedidoConsumerTrigger.Contrato;
using DroneDelivery.PedidoConsumerTrigger.Model;
using DroneDelivery.Shared.Utility.Events;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace DroneDelivery.PedidoConsumerTrigger.Command
{
    public class PedidoCommand : IPedidoCommand
    {

        private readonly IHttpClientFactory _factory;
        private readonly IUsuarioAutenticacao _usuarioAutenticacao;

        public PedidoCommand(IHttpClientFactory factory, IUsuarioAutenticacao usuarioAutenticacao)
        {
            _factory = factory;
            _usuarioAutenticacao = usuarioAutenticacao;
        }
        public async Task<bool> PedidoAsync(PedidoCriadoEvent @event)
        {
            var client = _factory.CreateClient(HttpClientName.PedidoEndPoint);
            var token = await _usuarioAutenticacao.GetToken();

            client
                   .DefaultRequestHeaders
                   .Authorization = new AuthenticationHeaderValue("Bearer",token);

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.PostAsJsonAsync("/api/pedidos", @event);
            return response.EnsureSuccessStatusCode().IsSuccessStatusCode;

        }


       
    }

}
