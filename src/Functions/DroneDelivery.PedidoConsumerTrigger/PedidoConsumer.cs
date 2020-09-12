using DroneDelivery.PedidoConsumerTrigger.Dto;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Kafka;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;


namespace DroneDelivery.PedidoConsumerTrigger
{
    public static class PedidoConsumer
    {

        [FunctionName(nameof(PedidoConsumer))]
        public static async Task PedidoConsumerGroupDroneDelivery(
            [KafkaTrigger(
            "%BootstrapServers%",
            "%Topic%",
            ConsumerGroup = "%ConsumerGroup%")]
            KafkaEventData<string> kafkaEvent,
            ILogger logger)
        {
            logger.LogInformation(kafkaEvent.Value.ToString());

            var baseUrl = Environment.GetEnvironmentVariable("UrlBasePedido");
            var email = Environment.GetEnvironmentVariable("Login");
            var password = Environment.GetEnvironmentVariable("Senha");

            var httpClient = new HttpClient
            {
                BaseAddress = new Uri(baseUrl)
            };

            var postUser = new
            {
                email,
                password
            };

            var loginResponse = await httpClient.PostAsJsonAsync("/api/usuarios/login", postUser);
            loginResponse.EnsureSuccessStatusCode();
            var data = await loginResponse.Content.ReadAsStringAsync();
            var jwt = JsonConvert.DeserializeObject<TokenDto>(data);

            httpClient
                    .DefaultRequestHeaders
                    .Authorization = new AuthenticationHeaderValue("Bearer", jwt.Jwt.Token);

            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var postData = JsonConvert.DeserializeObject<PedidoDto>(kafkaEvent.Value);
            var response = await httpClient.PostAsJsonAsync("/api/pedidos", postData);
            response.EnsureSuccessStatusCode();
        }

    }
}
