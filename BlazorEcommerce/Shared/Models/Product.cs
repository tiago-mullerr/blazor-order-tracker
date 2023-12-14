using System;
namespace BlazorEcommerce.Shared.Models
{
	public class Product
	{
        public Product()
        {
            ImageUrl = $"https://source.unsplash.com/random/200x200?sig={new Random().NextInt64()}";
        }

        public int Id { get; set; }
		public string? Title { get; set; }
		public string? Description { get; set; }
		public readonly string? ImageUrl;
        public decimal Price { get; set; }
		public int Quantity { get; set; }
	}
}

