using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SushiBarApp.Data.Models;
using SushiBarApp.ViewModels;

namespace SushiBarApp.Abstractions
{
    public interface ICategoryService
    {
        public Task<CategoryViewModel> CreateCategory(Category category);
        public Task<CategoryViewModel> ChangeCategoryName(Category category);
        public Task<CategoryViewModel> DeleteCategory(Guid categoryId);
        public IEnumerable<Category> GetCategories();
        public Task<string> GetCategoryNameById(Guid categoryId);
        public Task<Category> GetCategory(Guid categoryId);
    }
}
