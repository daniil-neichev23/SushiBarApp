using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SushiBarApp.Data.Models;

namespace SushiBarApp.ViewModels
{
    public class ProductViewModel
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string CategoryName { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
