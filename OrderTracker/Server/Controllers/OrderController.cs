using Microsoft.AspNetCore.Mvc;
using OrderTracker.Server.Services;

namespace OrderTracker.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderService _orderService;

        public OrderController(ILogger<OrderController> logger,
            IOrderService orderService)
        {
            _logger = logger;
            _orderService = orderService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var orders = _orderService.GetOrders();
            Thread.Sleep(1500);
            return Ok(orders);
        }
    }
}
