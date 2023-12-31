﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTracker.Shared.Models
{
    public class Customer
    {
        public Customer()
        {
            ProfilePic = $"https://source.unsplash.com/random/200x200?sig={new Random().NextInt64()}";
        }

        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }

        public readonly string? ProfilePic;
    }
}
