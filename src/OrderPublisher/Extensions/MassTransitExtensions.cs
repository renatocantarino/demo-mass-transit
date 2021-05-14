using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace OrderPublisher.Extensions
{
    public static class MassTransitExtensions
    {
        public static void MassTransitInitialize(this IServiceCollection services)
        {
            services.AddMassTransit(x =>
            {
                x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(
                    rbt =>
                    {
                        rbt.UseHealthCheck(provider);
                        rbt.Host(new Uri("rabbitmq://localhost"), host =>
                        {
                            host.Username("guest");
                            host.Password("guest");
                        });
                    }));
            });

            services.AddMassTransitHostedService();
        }
    }
}