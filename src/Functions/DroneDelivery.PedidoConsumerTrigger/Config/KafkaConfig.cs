namespace DroneDelivery.PedidoConsumerTrigger.Config
{
    public class KafkaConfig
    {
        public string BootstrapServers { get; set; }
        public string Topic { get; set; }
        public string ConsumerGroup { get; set; }
    }
}
