using DroneDelivery.PedidoConsumerTrigger.Contrato;
using DroneDelivery.PedidoConsumerTrigger.Model;
using DroneDelivery.Shared.Utility.Events;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace DroneDelivery.PedidoConsumerTrigger.Command
{
    public class PedidoComand : ICommand
    {

        private readonly IHttpClientFactory _factory;
        private readonly IAutorizacao _autorizacao;

        public PedidoComand(IHttpClientFactory factory, IAutorizacao autorizacao)
        {
            _factory = factory;
            _autorizacao = autorizacao;
        }
        public async Task<bool> PedidoAsync(PedidoCriadoEvent @event)
        {
            var client = _factory.CreateClient(HttpClientName.PedidoEndPoint);
            var token = await _autorizacao.GetToken();

            client
                   .DefaultRequestHeaders
                   .Authorization = new AuthenticationHeaderValue("Bearer",token);

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.PostAsJsonAsync("/api/pedidos", @event);
            return response.EnsureSuccessStatusCode().IsSuccessStatusCode;

        }


       
    }

}
