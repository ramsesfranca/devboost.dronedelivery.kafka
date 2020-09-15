using DroneDelivery.PedidoConsumerTrigger.Contrato;
using DroneDelivery.PedidoConsumerTrigger.Model;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Kafka;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Threading.Tasks;


namespace DroneDelivery.PagamentoConsumerTrigger
{
    public class PagamentoConsumer
    {
        private readonly IPagamentoCommand _PagamentoCommand;

        public PagamentoConsumer(IPagamentoCommand PagamentoCommand)
        {
            _PagamentoCommand = PagamentoCommand;
        }

        [FunctionName(nameof(PagamentoConsumer))]
        public async Task PagamentoConsumerTrigger(
            [KafkaTrigger(
                "%BootstrapServers%",
                "%Topic%",
                ConsumerGroup = "%ConsumerGroup%")]
            KafkaEventData<string> kafkaEvent,
            ILogger logger)
        {
            logger.LogInformation(kafkaEvent.Value.ToString());

            var @event = JsonConvert.DeserializeObject<PagamentoCriadoEvent>(kafkaEvent.Value);

            await _PagamentoCommand.PagamentoAsync(@event);
        }

    }
}