using Confluent.Kafka;
using DroneDelivery.PedidoProducer.Config;
using DroneDelivery.PedidoProducer.Dto;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace DroneDelivery.PedidoProducer.Services
{
    public class PedProducer : IPedProducer
    {
        private readonly IOptions<KafkaConfig> _options;

        public PedProducer(IOptions<KafkaConfig> options)
        {
            _options = options;
        }


        public async Task EnviarPedido(CriarPedidoDto pedidoDto)
        {

            var config = new ProducerConfig { BootstrapServers = _options.Value.BootstrapServers };

            //producer mais seguro
            config.Acks = _options.Value.Acks;
            config.EnableIdempotence = _options.Value.EnableIdempotence;
            config.MessageSendMaxRetries = _options.Value.MessageSendMaxRetries;
            config.MaxInFlight = _options.Value.MaxInFlight;

            //melhorar taxa de transferencia
            config.CompressionType = _options.Value.CompressionType;
            config.LingerMs = _options.Value.LingerMs;
            config.BatchSize = _options.Value.BatchSizeKB * 1024;

            using var producer = new ProducerBuilder<int, string>(config).Build();
            try
            {
                var value = JsonConvert.SerializeObject(pedidoDto);

                await producer.ProduceAsync(
                    _options.Value.Topic,
                    new Message<int, string> { Key = new Random().Next(0, 2), Value = value });
            }
            catch (ProduceException<int, string> e)
            {
                Console.WriteLine($"Falha ao entregar a mensagem: {e.Message} [{e.Error.Code}]");
            }
        }
    }
}
