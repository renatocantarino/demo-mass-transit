using GreenPipes;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using OrderConsumer.Consumers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderConsumer.Extensions
{
    public static class MassTransitExtensions
    {
        public static void MassTransitInitialize(this IServiceCollection services)
        {
            services.AddMassTransit(x =>
            {
                x.AddConsumer<TicketConsumer>();

                x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(
                    rbt =>
                    {
                        rbt.UseHealthCheck(provider);
                        rbt.Host(new Uri("rabbitmq://localhost"), host =>
                        {
                            host.Username("guest");
                            host.Password("guest");
                        });

                        rbt.ReceiveEndpoint("orderTicketQueue", ep =>
                        {
                            ep.PrefetchCount = 10;
                            ep.UseMessageRetry(r => r.Interval(2, 100));
                            ep.ConfigureConsumer<TicketConsumer>(provider);
                        });
                    }));
            });

            services.AddMassTransitHostedService();
        }
    }
}