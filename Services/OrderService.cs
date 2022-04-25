using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SushiBarApp.Abstractions;
using SushiBarApp.Data;
using SushiBarApp.Data.Models;
using SushiBarApp.ViewModels;

namespace SushiBarApp.Services
{
    public class OrderService : IOrderService
    {
        private readonly SushiAppDBContext _db;
        private readonly ShopCart _shopCart;
        public OrderService(SushiAppDBContext context, ShopCart shopCart)
        {
            _db = context;
            _shopCart = shopCart;
        }

        public void CreateOrder(Order order)
        {
            if(order.Id == Guid.Empty)
                order.Id = Guid.NewGuid();
            order.OrderTime =DateTime.Now;
            var items = _shopCart.ListShopItems;
            foreach (var item in items)
            {
                _db.OrderDetails.Add(new OrderDetails
                {
                    Id = Guid.NewGuid(),
                    OrderId = order.Id,
                    Order = order,
                    Product = item.Product,
                    Price = item.Price * item.Quantity,
                    ProductId = item.Product.Id
                });
            }
            _db.SaveChanges();
        }
        public IEnumerable<OrderDetails> GetOrderDetails(Guid orderId)
        {
            var list = _db.OrderDetails.Where(o=>o.OrderId == orderId).ToList();
            foreach (var item in list)
            {
                item.Product = _db.Products.FirstOrDefault(p=>p.Id == item.ProductId);
                item.Order = _db.Orders.FirstOrDefault(o => o.Id == item.OrderId);
            }
            return list;
        }
        public IEnumerable<Order> GetOrdersByEmail(string email)
        {
            var list = _db.Orders.Where(o => o.Email == email);
            return list.OrderBy(d => d.OrderTime);
        }

        public IEnumerable<Order> GetOrders()
        {
            var list = _db.Orders;
            return list.OrderBy(d => d.OrderTime);
        }
    }
}
