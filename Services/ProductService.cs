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
    
    public class ProductService : IProductService
    {
        private readonly SushiAppDBContext _db;

        public ProductService(SushiAppDBContext context)
        {
            _db = context;
        }
        
        private ProductViewModel MapProductModel(Product product)
        {
            return new ProductViewModel
            {
                Name = product.Name,
                Count = product.Count,
                Description = product.Description,
                Price = product.Price,
                CategoryName = _db.Categories.FirstOrDefault(c=>c.Id == product.CategoryId).Name
            };
        }
        public async Task<ProductViewModel> CreateProduct(Product product)
        {
            if (product.Id == Guid.Empty)
                product.Id = Guid.NewGuid();
            await _db.Products.AddAsync(product);
            await _db.SaveChangesAsync();
            return MapProductModel(product);
        }

        public async Task<ProductViewModel> DeleteProduct(Guid productId)
        {
            var product = await _db.Products.SingleOrDefaultAsync(p => p.Id == productId);
            _db.Products.Remove(product);
            await _db.SaveChangesAsync();
            return MapProductModel(product);
        }
        public async Task<Product> GetProductById(Guid productId)
        {
            var product = await _db.Products.SingleOrDefaultAsync(p => p.Id == productId);
            if(product == null)
                throw new ArgumentException("Товар не найден");
            return product;
        }
        public List<Category> GetAllCategories()
        {
            var categories = _db.Categories.ToList();
            return categories;
        }

        public async Task<IEnumerable<Product>> GetProducts(string categoryName)
        {
            if(string.IsNullOrEmpty(categoryName))
                return _db.Products.Where(e => e.IsFavourite).ToList();

            var category = await _db.Categories.SingleOrDefaultAsync(c => c.Name == categoryName);
            if(category == null)
                return new List<Product>();
            return from p in _db.Products
                join c in _db.Categories on p.CategoryId equals c.Id
                where category.Id == p.CategoryId
                select p;
        }

        public async Task<ProductViewModel> UpdateProduct(Product product)
        {
            var foundProduct = await _db.Products.SingleOrDefaultAsync(p => p.Id == product.Id);
            foundProduct.Description = product.Description;
            foundProduct.Name = product.Name;
            foundProduct.Price = product.Price;
            foundProduct.CategoryId = product.CategoryId;
            foundProduct.Count = product.Count;
            foundProduct.ImageData = product.ImageData;
            foundProduct.ImageMimeType = product.ImageMimeType;
            foundProduct.Volume = product.Volume;
            foundProduct.IsFavourite = product.IsFavourite;
            foundProduct.Type = product.Type;
            await _db.SaveChangesAsync();
            return MapProductModel(foundProduct);
        }
    }
}
