using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SushiBarApp.Abstractions;
using SushiBarApp.Data;
using SushiBarApp.Data.Models;

namespace SushiBarApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [Authorize]
        public async Task<IActionResult> CreateCategory(Category category)
        {
            if (string.IsNullOrEmpty(category.Name))
                return RedirectToAction("CreateCategory", "Admin");
            await _categoryService.CreateCategory(category);
            TempData["message"] = string.Format("Категория \"{0}\" была успешно создана", category.Name);
            return RedirectToAction("Index", "Admin");
        }
        [Authorize]
        public async Task<IActionResult> ChangeCategoryName(Category category)
        {
            if (string.IsNullOrEmpty(category.Name))
                return RedirectToAction("EditCategory", "Admin", new {categoryId= category.Id});
            await _categoryService.ChangeCategoryName(category);
            TempData["message"] = string.Format("Категория \"{0}\" была успешно изменена", category.Name);
            return RedirectToAction("Index","Admin");
        }
        public async Task<string> GetCategoryNameById(Guid categoryId)
        {
            return await _categoryService.GetCategoryNameById(categoryId);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> DeleteCategory(Guid categoryId)
        {
            await _categoryService.DeleteCategory(categoryId);
            TempData["message"] = "Категория была успешно удалена";
            return RedirectToAction("Index", "Admin");
        }
    }
}
