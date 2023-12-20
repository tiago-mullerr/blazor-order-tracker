using AutoBogus;
using Bogus;
using Microsoft.AspNetCore.Mvc;
using OrderTracker.Server.Services;
using OrderTracker.Shared.Enums;
using OrderTracker.Shared.Models;

namespace OrderTracker.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderTrackerController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderTrackerController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("{orderId}")]
        public IActionResult Get(int orderId)
        {
            var events = _orderService.GetOrderShipmentEvents(orderId);
            return Ok(events.AsQueryable());
        }
    }
}
