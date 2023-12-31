﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTracker.Shared.Models
{
    public class Order
    {
        public Order()
        {
            Customer = new Customer();
            Products = new List<Product>();
            ShipmentEvents = new List<ShipmentEvent>();
        }

        public int Id { get; set; }

        public decimal Amount
        {
            get
            {
                return Products.Sum(s => s.Price * s.Quantity);
            }
        }

        public string FormattedAmount
        {
            get
            {
                return $"${Amount}";
            }
        }

        public int Step { get; set; }

        public Customer Customer { get; set; }

        public List<Product> Products { get; set; }

        public List<ShipmentEvent> ShipmentEvents { get; set; }
    }
}
