using Microsoft.EntityFrameworkCore;
using SushiBarApp.Data.Models;

namespace SushiBarApp.Data
{
    public class SushiAppDBContext : DbContext
    {
        public SushiAppDBContext(DbContextOptions<SushiAppDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ShopCartItem> ShopCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
    }
}
