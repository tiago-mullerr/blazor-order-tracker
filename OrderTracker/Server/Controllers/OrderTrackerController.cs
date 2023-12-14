using AutoBogus;
using Bogus;
using Microsoft.AspNetCore.Mvc;
using OrderTracker.Shared.Enums;
using OrderTracker.Shared.Models;

namespace OrderTracker.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderTrackerController : ControllerBase
    {
        [HttpGet("{orderId}")]
        public IQueryable<ShipmentEvent> Get(int orderId)
        {
            return new AutoFaker<ShipmentEvent>()
                    .RuleFor(x => x.EventType, new Faker().PickRandom<ShipmentEventTypeEnum>())
                    .RuleFor(x => x.EventDate, new Faker().Date.Between(DateTime.Now, DateTime.Now.AddDays(60)))
                    .Generate(4).AsQueryable();
        }
    }
}
