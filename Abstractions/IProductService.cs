using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SushiBarApp.Data.Models;
using SushiBarApp.ViewModels;

namespace SushiBarApp.Abstractions
{
    public interface IProductService
    {
        public Task<IEnumerable<Product>> GetProducts(string categoryName);
        public Task<ProductViewModel> CreateProduct(Product product);
        public Task<ProductViewModel> UpdateProduct(Product product);
        public Task<ProductViewModel> DeleteProduct(Guid productId);
        public Task<Product> GetProductById(Guid productId);
        public List<Category> GetAllCategories();
    }
}
