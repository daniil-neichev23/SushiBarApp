using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SushiBarApp.Abstractions;
using SushiBarApp.Data.Models;
using Microsoft.AspNetCore.Http;

namespace SushiBarApp.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly Abstractions.IAuthorizationService _authorizationService;
        public AdminController(IProductService productService, ICategoryService categoryService, Abstractions.IAuthorizationService authorizationService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _authorizationService = authorizationService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.Categories = _productService.GetAllCategories();
            if (! await _authorizationService.IsAdmin(User.Claims))
                return RedirectToAction("Login", "Account");
            return View(await _productService.GetProducts(string.Empty));
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid productId)
        {
            ViewBag.Categories = _productService.GetAllCategories();
            if (!await _authorizationService.IsAdmin(User.Claims))
                return RedirectToAction("Login", "Account");
            return View(await _productService.GetProductById(productId));
        }
        [HttpGet]
        public async Task<IActionResult> EditCategory(Guid categoryId)
        {
            if (!await _authorizationService.IsAdmin(User.Claims))
                return RedirectToAction("Login", "Account");
            return View( await _categoryService.GetCategory(categoryId));
        }
        [HttpGet]
        public async Task<IActionResult> CreateCategory()
        {
            if (!await _authorizationService.IsAdmin(User.Claims))
                return RedirectToAction("Login", "Account");
            return View(new Category());
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Product product, IFormFile image = null)
        {
            ViewBag.Categories = _productService.GetAllCategories();
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    product.ImageMimeType = image.ContentType;
                    product.ImageData = new byte[image.Length];
                    image.OpenReadStream().Read(product.ImageData, 0, (int)image.Length);
                }
                await _productService.UpdateProduct(product);
                TempData["message"] = string.Format("Изменения в игре \"{0}\" были сохранены", product.Name);
                return RedirectToAction("Index");
            }
            TempData["error"] = "Ошибка изменения товара, некорректный ввод";
            return View(product);
        }
        [HttpGet]
        public async  Task<IActionResult> Create()
        {
            if (!await _authorizationService.IsAdmin(User.Claims))
                return RedirectToAction("Login", "Account");
            ViewBag.Categories = _productService.GetAllCategories();
            return View(new Product());
        }
    }
}
