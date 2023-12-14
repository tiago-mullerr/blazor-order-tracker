using System;
using AutoBogus;
using Bogus;
using Microsoft.AspNetCore.Mvc;
using OrderTracker.Shared.Models;

namespace OrderTracker.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly Faker<Product> _productGenerator;
        private readonly Faker<Customer> _customerGenerator;

        public OrderController(ILogger<OrderController> logger)
        {
            _logger = logger;
            _productGenerator = new AutoFaker<Product>()
                .RuleFor(x => x.Title, new Faker().Commerce.ProductName)
                .RuleFor(x => x.Description, new Faker().Commerce.ProductDescription)
                .RuleFor(x => x.Quantity, new Faker().Random.Int(1, 100))
                .RuleFor(x => x.Id, new Faker().Random.Int(1, 1000))
                .RuleFor(x => x.Price, new Faker().Random.Decimal((decimal)0.01, (decimal)99.99));

            _customerGenerator = new AutoFaker<Customer>()
                .RuleFor(x => x.Address, new Faker().Address.StreetAddress())
                .RuleFor(x => x.City, new Faker().Address.City())
                .RuleFor(x => x.Country, new Faker().Address.Country())
                .RuleFor(x => x.FirstName, new Faker().Name.FirstName())
                .RuleFor(x => x.LastName, new Faker().Name.LastName())
                .RuleFor(x => x.Id, new Faker().Random.Int(1));
        }

        [HttpGet]
        public List<Order> Get()
        {
            var orders = new AutoFaker<Order>()
                .RuleFor(x => x.Id, new Faker().Random.Int(1, 1000))
                .Generate(10);

            orders.ForEach(f =>
            {
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
    }
}
