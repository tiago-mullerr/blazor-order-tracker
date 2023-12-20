using AutoBogus;
using Bogus;
using OrderTracker.Shared.Enums;
using OrderTracker.Shared.Models;

namespace OrderTracker.Server.Services
{
    public interface IOrderService
    {
        List<Order> GetOrders();

        List<ShipmentEvent> GetOrderShipmentEvents(int orderId);
    }

    public class OrderService : IOrderService
    {
        public OrderService() { }

        public List<ShipmentEvent> GetOrderShipmentEvents(int orderId)
        {
            var events = new AutoFaker<ShipmentEvent>().GenerateBetween(1, 4);

            events.ForEach(f =>
            {
                f.EventDate = new Faker().Date.Between(DateTime.Now, DateTime.Now.AddDays(60));
                f.EventType = new Faker().PickRandom<ShipmentEventTypeEnum>();
                f.FromAddress = new Faker().Address.StreetAddress(true);
                f.ToAddress = new Faker().Address.StreetAddress(true);
            });

            events = events.OrderBy(o => o.EventDate).ThenBy(o => o.EventType).ToList();

            return events;
        }

        public List<Order> GetOrders()
        {
            var orders = new AutoFaker<Order>().Generate(10);

            var _productsFactory = new AutoFaker<Product>()
                .RuleFor(x => x.Title, new Faker().Commerce.ProductName)
                .RuleFor(x => x.Description, new Faker().Commerce.ProductDescription)
                .RuleFor(x => x.Quantity, new Faker().Random.Int(1, 100))
                .RuleFor(x => x.Id, new Faker().Random.Int(1, 1000))
                .RuleFor(x => x.Price, new Faker().Random.Decimal((decimal)0.01, (decimal)99.99));

            orders.ForEach(f =>
            {
                f.Id = new Faker().Random.Int(1, 1000);
                f.Step = new Faker().Random.Int(1, 4);
                f.Products = _productsFactory.GenerateBetween(2, 5);
                f.Customer = new AutoFaker<Customer>()
                    .RuleFor(x => x.Address, new Faker().Address.StreetAddress())
                    .RuleFor(x => x.City, new Faker().Address.City())
                    .RuleFor(x => x.Country, new Faker().Address.Country())
                    .RuleFor(x => x.FirstName, new Faker().Name.FirstName())
                    .RuleFor(x => x.LastName, new Faker().Name.LastName())
                    .RuleFor(x => x.Id, new Faker().Random.Int(1));
            });

            return orders;
        }
    }
}
