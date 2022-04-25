using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SushiBarApp.Data;
using SushiBarApp.Data.Models;
using SushiBarApp.ViewModels;

namespace SushiBarApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly SushiAppDBContext db;
        private readonly Abstractions.IAuthorizationService _authorizationService;
        private readonly ShopCart _shopCart;

        public AccountController(SushiAppDBContext context, ShopCart shopCart, Abstractions.IAuthorizationService authorizationService)
        {
            db = context;
            _shopCart = shopCart;
            _authorizationService = authorizationService;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await db.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
                if (user != null && user.Password == _authorizationService.GetHash(model.Password))
                {
                    await Authenticate(model.Email);
                    _shopCart.ClearShopCart();
                    return RedirectToAction("GetProducts", "Product");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(User model)
        {
            //db.Users.Add(new User
            //{
            //    Email = "Admin@test.com",
            //    Id = Guid.NewGuid(),
            //    Name = "Admin",
            //    Password = _authorizationService.GetHash("Admin"),
            //    PhoneNumber = "1111111111",
            //    Role = "Admin"
            //});
            //db.SaveChanges();
            //return View(model);

            if (model.Id == Guid.Empty)
                model.Id = Guid.NewGuid();
            model.Role = "User";
            if (ModelState.IsValid)
            {
                var user = await db.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
                if (user != null)
                {
                    ModelState.AddModelError("", "Такой пользователь уже существует");
                }
                model.Password = _authorizationService.GetHash(model.Password);
                _shopCart.ClearShopCart();
                await db.Users.AddAsync(model);
                await db.SaveChangesAsync();
                await Authenticate(model.Email);
                return RedirectToAction("GetProducts", "Product");

            }
            return View(model);
        }
        [HttpGet]
        public PartialViewResult AuthState()
        {
            if (User.Claims.Count() != 0)
                return PartialView(true);
            return PartialView(false);
        }
       
        private async Task Authenticate(string userName)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            _shopCart.ClearShopCart();
            return RedirectToAction("GetProducts", "Product");
        }
    }
}
