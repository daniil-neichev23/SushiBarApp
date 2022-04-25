using System;

namespace SushiBarApp.Data.Models
{
    public class ShopCartItem
    {
        public Guid Id { get; set; }
        public Product Product { get; set; }
        public decimal Price { get; set; }
        public string CartId { get; set; }
        public int Quantity { get; set; } = 0;
    }
}
