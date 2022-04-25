using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SushiBarApp.Abstractions;
using SushiBarApp.Data;
using SushiBarApp.Data.Models;
using SushiBarApp.ViewModels;

namespace SushiBarApp.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly SushiAppDBContext _db;
        public CategoryService(SushiAppDBContext context)
        {
            _db = context;
        }
        public async Task<CategoryViewModel> ChangeCategoryName(Category category)
        {
            var foundCategory = await GetCategoryById(category.Id);
            if (string.IsNullOrEmpty(category.Name))
                return MapCategoryModel(category);
            foundCategory.Name = category.Name;
            await _db.SaveChangesAsync();
            return MapCategoryModel(category);
        }

        public async Task<CategoryViewModel> CreateCategory(Category category)
        {
            var foundCategory = await _db.Categories.SingleOrDefaultAsync(c => c.Id == category.Id);
            if(foundCategory != null)
                throw new ArgumentException("Категория с таким именем уже существует");
            if(category.Id == Guid.Empty)
                category.Id = Guid.NewGuid();
            await _db.Categories.AddAsync(category);
            await _db.SaveChangesAsync();
            return MapCategoryModel(category);
        }

        public IEnumerable<Category> GetCategories()
        {
            return _db.Categories.ToList();
        }
        public async Task<CategoryViewModel> DeleteCategory(Guid categoryId)
        {
            var category = await GetCategoryById(categoryId);
            var mapModel =  MapCategoryModel(category);
            _db.RemoveRange(mapModel.Products);
            _db.Categories.Remove(category);
            await _db.SaveChangesAsync();
            return MapCategoryModel(category);
        }

        private async Task<Category> GetCategoryById(Guid categoryId)
        {
            var category = await _db.Categories.SingleOrDefaultAsync(c=>c.Id == categoryId);
            if (category == null)
                throw new ArgumentException("Категория не найдена");
            return category;
        }
        private CategoryViewModel MapCategoryModel(Category category)
        {
            return new CategoryViewModel
            {
                CategoryName = category.Name,
                Products = from p in _db.Products
                    join c in _db.Categories on p.CategoryId equals c.Id
                    where category.Id == p.CategoryId
                    select p
            };
        }

        public async  Task<Category> GetCategory(Guid categoryId)
        {
            var result = await GetCategoryById(categoryId);
            return result;
        }
        public async Task<string> GetCategoryNameById(Guid categoryId)
        {
            var category =await  GetCategoryById(categoryId);
            return category.Name;
        }
    }
}
