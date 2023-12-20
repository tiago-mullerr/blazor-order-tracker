using AutoBogus;
using Bogus;
using OrderTracker.Shared.Models;

namespace OrderTracker.Server.Services
{
    public interface IProductService
    {
        List<Product> GetProducts();
    }

    public class ProductService : IProductService
    {
        public List<Product> GetProducts()
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

            return products;
        }
    }
}
