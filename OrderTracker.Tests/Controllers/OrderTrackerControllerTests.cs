using AutoBogus;
using Bogus;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using OrderTracker.Client.Pages;
using OrderTracker.Server.Controllers;
using OrderTracker.Server.Services;
using OrderTracker.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTracker.Tests.Controllers
{
    public class OrderTrackerControllerTests
    {
        private readonly OrderTrackerController _controller;
        private readonly IOrderService _orderService;

        public OrderTrackerControllerTests()
        {
            _orderService = Substitute.For<IOrderService>();
            _controller = new OrderTrackerController(_orderService);
        }

        [Fact]
        public void GetShipmentEvents()
        {
            var randomOrderId = new Faker().Random.Int(min: 0);
            var expectedEvents = new AutoFaker<ShipmentEvent>().Generate(3);
            _orderService.GetOrderShipmentEvents(randomOrderId).Returns(expectedEvents);
            var events = _controller.Get(randomOrderId);
            events.Should().BeOfType<OkObjectResult>();
            (events as OkObjectResult).Value.Should().BeEquivalentTo(expectedEvents);
        }
    }
}
