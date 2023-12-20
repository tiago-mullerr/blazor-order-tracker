using System;
using AutoBogus;
using Bogus;
using Microsoft.AspNetCore.Mvc;
using OrderTracker.Shared.Enums;
using OrderTracker.Shared.Models;
using OrderTracker.Shared.Services;

namespace OrderTracker.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly Faker<Product> _productGenerator;
        private readonly SessionService _sessionService;

        public OrderController(ILogger<OrderController> logger,
            SessionService sessionService)
        {
            _logger = logger;
            _productGenerator = new AutoFaker<Product>()
                .RuleFor(x => x.Title, new Faker().Commerce.ProductName)
                .RuleFor(x => x.Description, new Faker().Commerce.ProductDescription)
                .RuleFor(x => x.Quantity, new Faker().Random.Int(1, 100))
                .RuleFor(x => x.Id, new Faker().Random.Int(1, 1000))
                .RuleFor(x => x.Price, new Faker().Random.Decimal((decimal)0.01, (decimal)99.99));
            _sessionService = sessionService;
        }

        [HttpGet]
        public List<Order> Get()
        {
            var orders = new AutoFaker<Order>().Generate(10);

            orders.ForEach(f =>
            {
                f.Id = new Faker().Random.Int(1, 1000);
                f.Step = new Faker().Random.Int(1, 4);
                f.Products = _productGenerator.GenerateBetween(2, 5);
                f.Customer = new AutoFaker<Customer>()
                    .RuleFor(x => x.Address, new Faker().Address.StreetAddress())
                    .RuleFor(x => x.City, new Faker().Address.City())
                    .RuleFor(x => x.Country, new Faker().Address.Country())
                    .RuleFor(x => x.FirstName, new Faker().Name.FirstName())
                    .RuleFor(x => x.LastName, new Faker().Name.LastName())
                    .RuleFor(x => x.Id, new Faker().Random.Int(1));
            });

            Thread.Sleep(1500);
            return orders;
        }

        [HttpGet("new-order-details")]
        public async Task<IActionResult> GetPendingNewOrderDetails()
        {
            var existingPendingOrder = await _sessionService.GetExistingNewOrderTemplate();
            return Ok(existingPendingOrder);
        }

        [HttpPost("new-order-details")]
        public async Task<IActionResult> SavePendingNewOrderDetails(Order order)
        {
            await _sessionService.SaveKey("NewOrder", order);
            return Ok();
        }

        [HttpDelete("new-order-details")]
        public async Task<IActionResult> DeletePendingNewOrderDetails()
        {
            await _sessionService.ClearStorageKey("NewOrder");
            return Ok();
        }
    }
}
