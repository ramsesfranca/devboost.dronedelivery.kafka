using DroneDelivery.PedidoConsumerTrigger.Config;
using DroneDelivery.PedidoConsumerTrigger.Contrato;
using DroneDelivery.PedidoConsumerTrigger.Model;
using DroneDelivery.Shared.Utility.Events;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace DroneDelivery.PedidoConsumerTrigger.Command
{
    public class UsuarioAutenticacao : IUsuarioAutenticacao
    {
        private readonly IHttpClientFactory _factory;
        private readonly AppConfig _appConfig;

        public UsuarioAutenticacao(IHttpClientFactory factory, IOptions<AppConfig> options)
        {
            _factory = factory;
            _appConfig = options.Value;

        }
        public async Task<string> GetToken()
        {
            var client = _factory.CreateClient(HttpClientName.PedidoEndPoint);
            var loginResponse = await client.PostAsJsonAsync("/api/usuarios/login", new
            {
                email = _appConfig.Login,
                password = _appConfig.Senha
            });

            loginResponse.EnsureSuccessStatusCode();
            var data = await loginResponse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TokenDto>(data).Jwt.Token;
        }
    }
}
