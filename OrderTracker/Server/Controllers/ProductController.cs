using AutoBogus;
using Bogus;
using Microsoft.AspNetCore.Mvc;
using OrderTracker.Server.Services;
using OrderTracker.Shared.Models;

namespace OrderTracker.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var products = _productService.GetProducts();
            return Ok(products);
        }
    }
}
