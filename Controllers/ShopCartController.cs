using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SushiBarApp.Abstractions;
using SushiBarApp.Data;
using SushiBarApp.Data.Models;
using SushiBarApp.Hubs;
using SushiBarApp.ViewModels;

namespace SushiBarApp.Controllers
{
    public class Temp
    {
        public static bool isInit = true;
    }
    public class ShopCartController : Controller
    {
        private readonly IProductService _productService;
        SushiAppDBContext _context;
        private readonly ShopCart _shopCart;
        IHubContext<SushiHub> hubContext;


        public ShopCartController(IProductService productService, ShopCart shopCart,
            IHubContext<SushiHub> _hubcontext,SushiAppDBContext context)
        {
            _productService = productService;
            _shopCart = shopCart;
            hubContext = _hubcontext;
            _context = context;
        }
        public PartialViewResult Summary()
        {
            var items = _shopCart.GetShopItems();
            _shopCart.ListShopItems = items;
            return PartialView(_shopCart);
        }
        public IActionResult Index()
        {
            var items = _shopCart.GetShopItems();
            _shopCart.ListShopItems = items;
            var obj = new ShopCartViewModel
            {
                ShopCart = _shopCart
            };
            return View(obj);
        }
        [HttpGet]
        public IActionResult GetItemsFromCart()
        {
            var items = _shopCart.GetShopItems();
            _shopCart.ListShopItems = items;
            var obj = new ShopCartViewModel
            {
                ShopCart = _shopCart
            };
            return Ok(obj);
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToCart(Guid id)
        //public IActionResult AddToCart(Guid id)
        {
            if (Temp.isInit)
            {
                _shopCart.ClearShopCart();
                Temp.isInit = false;
            }
            var item = _productService.GetProducts("").Result.FirstOrDefault(i => i.Id == id);
            if(item !=null)
                 await _shopCart.AddToCart(item);
            //_shopCart.AddToCart(item);
            await hubContext.Clients.All.SendAsync("LoadItems");
 
            return RedirectToAction("GetProducts","Product");
        }

        public async Task<IActionResult> RemoveFromCart(Guid productId)
        {
            await _shopCart.RemoveItem(productId);
            await hubContext.Clients.All.SendAsync("LoadItems");
            return RedirectToAction("Index");
        }
        
    }
}
