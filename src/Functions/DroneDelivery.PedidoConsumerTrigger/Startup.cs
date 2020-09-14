using DroneDelivery.PedidoConsumerTrigger.Command;
using DroneDelivery.PedidoConsumerTrigger.Contrato;
using DroneDelivery.Shared.Utility.Events;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;

[assembly: FunctionsStartup(typeof(DroneDelivery.PedidoConsumerTrigger.Startup))]
namespace DroneDelivery.PedidoConsumerTrigger
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddHttpClient(HttpClientName.PedidoEndPoint, opts =>
            {
                opts.BaseAddress = new Uri("https://localhost:5001/");
            });
            builder.Services.AddScoped<IAutorizacao, Autorizacao>();
            builder.Services.AddScoped<ICommand,PedidoComand>();
                      
        }
    }
}
