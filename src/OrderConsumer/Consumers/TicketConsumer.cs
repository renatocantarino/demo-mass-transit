using MassTransit;
using Microsoft.Extensions.Logging;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderConsumer.Consumers
{
    public class TicketConsumer : IConsumer<Ticket>
    {
        private readonly ILogger<TicketConsumer> _internalLogger;

        public TicketConsumer(ILogger<TicketConsumer> internalLogger)
        {
            _internalLogger = internalLogger;
        }

        public async Task Consume(ConsumeContext<Ticket> context)
        {
            await Console.Out.WriteLineAsync(context.Message.UserName);

            _internalLogger.LogInformation($"Mensagem recebida:{context.Message.Id} => {context.Message.Location}");
        }
    }
}