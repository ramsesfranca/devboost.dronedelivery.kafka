﻿namespace DroneDelivery.PedidoConsumerTrigger.Dto
{
    public class TokenDto
    {
        public string Email { get; set; }
        public JwtTokenDto Jwt { get; set; }

    }

    public class JwtTokenDto
    {
        public string Token { get; set; }
    }
}
