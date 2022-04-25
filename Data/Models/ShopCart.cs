using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SushiBarApp.Abstractions;

namespace SushiBarApp.Data.Models
{
    public class ShopCart
    {
        private readonly SushiAppDBContext _db;
        public ShopCart(SushiAppDBContext context)
        {
            _db = context;
        }
        public string ShopCartId { get; set; } //id for session
        public List<ShopCartItem> ListShopItems { get; set; }
        public static ShopCart GetCart(IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = service.GetService<SushiAppDBContext>();
            string shopCartId = session.GetString("CartId");

            if (shopCartId == null)
                shopCartId = Guid.NewGuid().ToString();

            session.SetString("CartId", shopCartId);
            return new ShopCart(context){ShopCartId = shopCartId};
        }
        public async Task AddToCart(Product product)
       // public void AddToCart(Product product)
        {
            var item = _db.ShopCartItems.FirstOrDefault(p => p.Product.Id == product.Id);
            if (item == null)
            {
                _db.ShopCartItems.Add(new ShopCartItem
                {
                    Id = Guid.NewGuid(),
                    CartId = ShopCartId,
                    Product = product,
                    Price = product.Price,
                    Quantity = 1
                });
            }
            else item.Quantity++;
             await _db.SaveChangesAsync();
             //_db.SaveChanges();
        }
        public void ClearShopCart()
        {
            _db.ShopCartItems.RemoveRange(_db.ShopCartItems.ToList());
            _db.SaveChanges();
        }
        public decimal ComputeTotalValue() => ListShopItems.Sum(e => e.Product.Price * e.Quantity);

        public async Task RemoveItem(Guid productId)
        {

            var item = await _db.ShopCartItems.FirstOrDefaultAsync(p => p.Product.Id == productId);
            _db.ShopCartItems.Remove(item);
            await _db.SaveChangesAsync();
        }
        public List<ShopCartItem> GetShopItems()
        {
            return _db.ShopCartItems.Where(c => c.CartId == ShopCartId).Include(s => s.Product).ToList();
        }
    }
}
