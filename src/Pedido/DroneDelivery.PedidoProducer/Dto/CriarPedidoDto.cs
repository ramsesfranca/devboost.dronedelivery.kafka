using System;

namespace DroneDelivery.PedidoProducer.Dto
{
    public class CriarPedidoDto
    {
        public double Peso { get; set; }

        public double Valor { get; set; }

        public Guid Id { get; private set; }

        public CriarPedidoDto()
        {
            Id = Guid.NewGuid();
        }
    }
}
