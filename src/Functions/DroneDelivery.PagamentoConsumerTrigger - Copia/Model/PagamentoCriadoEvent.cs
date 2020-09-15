using System;

namespace DroneDelivery.PedidoConsumerTrigger.Model
{
    public class PagamentoCriadoEvent
    {
        public Guid Id { get; set; }

        public double Peso { get; set; }

        public double Valor { get; set; }
    }
}
