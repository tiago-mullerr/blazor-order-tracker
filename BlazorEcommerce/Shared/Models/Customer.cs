﻿using System;
namespace BlazorEcommerce.Shared.Models
{
    public class Customer
    {
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
    }
}

