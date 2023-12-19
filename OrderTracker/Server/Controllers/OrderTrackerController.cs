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
        public IActionResult Get(int orderId)
        {
            var addresses = new AutoFaker<ShipmentEvent>().GenerateBetween(1, 4);

            addresses.ForEach(f =>
            {
                f.EventDate = new Faker().Date.Between(DateTime.Now, DateTime.Now.AddDays(60));
                f.EventType = new Faker().PickRandom<ShipmentEventTypeEnum>();
                f.FromAddress = new Faker().Address.StreetAddress(true);
                f.ToAddress = new Faker().Address.StreetAddress(true);
            });

            addresses = addresses.OrderBy(o => o.EventDate).ThenBy(o => o.EventType).ToList();

            return Ok(addresses.AsQueryable());
        }
    }
}
