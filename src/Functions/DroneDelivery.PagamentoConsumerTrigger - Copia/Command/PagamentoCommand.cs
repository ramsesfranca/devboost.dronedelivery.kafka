using DroneDelivery.PedidoConsumerTrigger.Contrato;
using DroneDelivery.PedidoConsumerTrigger.Model;
using DroneDelivery.Shared.Utility.Events;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace DroneDelivery.PagamentoConsumerTrigger.Command
{
    public class PagamentoCommand : IPagamentoCommand
    {

        private readonly IHttpClientFactory _factory;

        public PagamentoCommand(IHttpClientFactory factory)
        {
            _factory = factory;
        }
        public async Task<bool> PagamentoAsync(PagamentoCriadoEvent @event)
        {
            var client = _factory.CreateClient(HttpClientName.PagamentoEndPoint);

            client
                   .DefaultRequestHeaders
                   .Authorization = new AuthenticationHeaderValue("Bearer");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.PostAsJsonAsync("/api/pedidos", @event);
            return response.EnsureSuccessStatusCode().IsSuccessStatusCode;

        }



    }

}
