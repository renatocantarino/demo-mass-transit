using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Shared.Model;
using System;
using System.Threading.Tasks;

namespace OrderPublisher.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IBus _massTransitBus;

        public OrderController(IBus massTransitBus) => this._massTransitBus = massTransitBus;

        [HttpPost]
        public async Task<IActionResult> CreateTicker(Ticket ticket)
        {
            if (ticket == null) return BadRequest();

            ticket.Booked = DateTime.Now;
            var endpoint = await _massTransitBus.GetSendEndpoint(GetUri());
            await endpoint.Send(ticket);

            return Ok();
        }

        private static Uri GetUri() => new("rabbitmq://localhost/orderTicketQueue");
    }
}