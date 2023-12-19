using AutoBogus;
using Bogus;
using Microsoft.AspNetCore.Mvc;
using OrderTracker.Shared.Models;

namespace OrderTracker.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var products = new AutoFaker<Product>().Generate(10);

            products.ForEach(f =>
            {
                f.Title = new Faker().Commerce.ProductName();
                f.Description = new Faker().Commerce.ProductDescription();
                f.Price = new Faker().Finance.Amount((decimal)0.99);
                f.Id = new Faker().Random.Int(1, 999);
                f.Quantity = 1;
            });

            return Ok(products);
        }
    }
}
