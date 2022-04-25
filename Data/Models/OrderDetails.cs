﻿using System;

namespace SushiBarApp.Data.Models
{
    public class OrderDetails
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
        public decimal Price { get; set; }

    }
}
