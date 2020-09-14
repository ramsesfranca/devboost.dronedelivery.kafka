using DroneDelivery.PedidoConsumerTrigger.Contrato;
using DroneDelivery.PedidoConsumerTrigger.Model;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Kafka;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Threading.Tasks;


namespace DroneDelivery.PedidoConsumerTrigger
{
    public class PedidoConsumer
    {
        private readonly ICommand _command;

        public PedidoConsumer(ICommand command)
        {
            _command = command;
        }
        
        [FunctionName(nameof(PedidoConsumer))]
        public  async Task PedidoConsumerGroupDroneDelivery(
            [KafkaTrigger(
            "localhost:9092",
            "pedido-criado-evento",
            ConsumerGroup = "pedido-criado-evento")]
            KafkaEventData<string> kafkaEvent,
            ILogger logger)
        {
            logger.LogInformation(kafkaEvent.Value.ToString());
            var postData = JsonConvert.DeserializeObject<PedidoCriadoEvent>(kafkaEvent.Value);
            await  _command.PedidoAsync(postData);
                      
          
        }

    }
}
