using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SushiBarApp.Data.Models;

namespace SushiBarApp.ViewModels
{
    public class CategoryViewModel
    {
        public string CategoryName { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
