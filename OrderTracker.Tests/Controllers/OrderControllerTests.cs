using NSubstitute;
using OrderTracker.Server.Controllers;
using OrderTracker.Server.Services;
using Microsoft.Extensions.Logging;
using AutoBogus;
using OrderTracker.Shared.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace OrderTracker.Tests.Controllers
{
    public class OrderControllerTests
    {
        private readonly OrderController _controller;
        private readonly IOrderService _orderService;
        private readonly ILogger<OrderController> _logger;

        public OrderControllerTests()
        {
            _orderService = Substitute.For<IOrderService>();
            _logger = Substitute.For<ILogger<OrderController>>();
            _controller = new OrderController(_logger, _orderService);
        }

        [Fact]
        public void GetOrders()
        {
            var expectedOrders = new AutoFaker<Order>().Generate(3);
            _orderService.GetOrders().ReturnsForAnyArgs(expectedOrders);
            var orders = _controller.Get();
            orders.Should().BeOfType<OkObjectResult>();
            (orders as OkObjectResult).Value.Should().Be(expectedOrders);
        }
    }
}
