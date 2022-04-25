using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SushiBarApp.Abstractions;
using SushiBarApp.Data;
using SushiBarApp.Data.Models;
using IAuthorizationService = SushiBarApp.Abstractions.IAuthorizationService;

namespace SushiBarApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IAuthorizationService _authorizationService;
        private readonly ShopCart _shopCart;

        public OrderController(IOrderService orderService,ShopCart shopCart, IAuthorizationService authorizationService)
        {
            _orderService = orderService;
            _shopCart = shopCart;
            _authorizationService = authorizationService;
        }
        [HttpGet]
        public IActionResult Checkout()
        {
            var user = _authorizationService.GetUser(User.Claims);
            if (user == null)
                return View();
            return Checkout(new Order
            {
                Id = Guid.NewGuid(),
                Email = user.Email,
                Name = user.Name,
                OrderTime = DateTime.Now,
                Phone = user.PhoneNumber
            });
        }
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            _shopCart.ListShopItems = _shopCart.GetShopItems();
            if (_shopCart.ListShopItems.Count == 0)
                ModelState.AddModelError("","Ваша корзина пуста");
            if (ModelState.IsValid)
            {
                _orderService.CreateOrder(order);
                return RedirectToAction("Complete");
            }
            return RedirectToAction("Index","ShopCart");
        }
        [HttpGet]
        public IActionResult Complete()
        {
            _shopCart.ClearShopCart();
            ViewBag.Message = "Заказ успешно обработан";
            return View();
        }
        [HttpGet]
        public IActionResult GetAllOrders()
        {
            var user = _authorizationService.GetUser(User.Claims);
            if (user == null)
                return RedirectToAction("GetProducts", "Product");
            var list = _orderService.GetOrdersByEmail(user.Email);
            return View(list);
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetOrdersByAdmin()
        {
            if (! await _authorizationService.IsAdmin(User.Claims))
                return RedirectToAction("GetProducts", "Product");
            var orders = _orderService.GetOrders();
            return View(orders);
        }
        [HttpGet]
        public IActionResult GetOrderDetails(Guid orderId)
        {
            var details = _orderService.GetOrderDetails(orderId);
            return View(details);
        }
    }
}
