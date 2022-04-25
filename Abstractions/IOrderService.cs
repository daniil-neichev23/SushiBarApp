using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SushiBarApp.Data.Models;

namespace SushiBarApp.Abstractions
{
    public interface IOrderService
    {
        public void CreateOrder(Order order);
        public IEnumerable<Order> GetOrdersByEmail(string email);
        public IEnumerable<OrderDetails> GetOrderDetails(Guid orderId);
        public IEnumerable<Order> GetOrders();
    }
}
