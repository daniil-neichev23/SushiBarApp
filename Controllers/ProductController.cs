using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronPython.Hosting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SushiBarApp.Abstractions;
using SushiBarApp.Data;
using SushiBarApp.Data.Models;

namespace SushiBarApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        SushiAppDBContext _context;

        public ProductController(IProductService productService,
            SushiAppDBContext context)
        {
            _productService = productService;
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetProducts(string categoryName)
        {
            ViewBag.CurrentCategory = categoryName;
            return View(await _productService.GetProducts(categoryName));
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product product, IFormFile image = null)
        {
            if (product.Id == Guid.Empty)
                product.Id = Guid.NewGuid();
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    product.ImageMimeType = image.ContentType;
                    product.ImageData = new byte[image.Length];
                    image.OpenReadStream().Read(product.ImageData, 0, (int)image.Length);
                }
                await _productService.CreateProduct(product);
                TempData["message"] = string.Format("Товар \"{0}\" был успешно создан", product.Name);
                return RedirectToAction("Index", "Admin");
            }
            TempData["error"] = "Ошибка создания товара, некорректный ввод";
            return RedirectToAction("Create", "Admin");
        }
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(Product product)
        {
            return new OkObjectResult(await _productService.UpdateProduct(product));
        }
        [HttpGet]
        public FileContentResult GetImage(Guid productId)
        {
            var product = _productService.GetProductById(productId);
            if (product != null)
                return File(product.Result.ImageData, product.Result.ImageMimeType);
            return null;
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> DeleteProduct(Guid productId)
        {
            var deleted = await _productService.DeleteProduct(productId);
            TempData["message"] = string.Format("Продукт \"{0}\" был удалён", deleted.Name);
            return RedirectToAction("Index", "Admin");
        }
        [HttpGet]
        public IActionResult ProductInfo(Guid id)
        {
            if (id == null) return RedirectToAction("Index");
            var line = _context.Products.Where(line => line.Id == id).FirstOrDefault();
            return View(line);
        }
        [HttpPost]
        public IActionResult AddReview(Guid id, string text)
        {
            // if (text == null || text=="")
            var line = _context.Products.Where(line => line.Id == id).FirstOrDefault();
            var rev = new Review()
            {
            Text = text
            };
            if (line.Reviews == null)
            {
                //It's null - create it
                line.Reviews = new List<Review>();
            }

            line.Reviews.Add(rev);
            _context.SaveChanges();
            return RedirectToAction("ViewReviews",new { id = line.Id });
        }
        public IActionResult ViewReviews(Guid id)
        {

            //var posts = _context.Products.Where(line => line.Id == id).Select(p => p.Reviews).ToList();
            //var engine = Python.CreateEngine();

            //var path = @"C:\Users\User\OneDrive\DaysBetweenDates.py";
            //var source = engine.CreateScriptSourceFromFile(path);

            //ICollection<string> paths = engine.GetSearchPaths();
            //string dir = @"C:\Users\User\AppData\Local\Programs\Python\Python39\Lib\";
            //paths.Add(dir);
            //string dir2 = @"C:\Users\User\AppData\Local\Programs\Python\Python39\Lib\site-packages\";
            //paths.Add(dir2);
            //engine.SetSearchPaths(paths);

            //var list = new List<string>();
            //list.Add("");
            //list.Add("null");

            //engine.GetSysModule().SetVariable("argv", list);

            //var eIO = engine.Runtime.IO;
            //var errors = new MemoryStream();
            //eIO.SetErrorOutput(errors, Encoding.Default);

            //var result = new MemoryStream();
            //eIO.SetOutput(result, Encoding.Default);

            //var scope = engine.CreateScope();
            //source.Execute(scope);

            //string st(byte[] x) => Encoding.Default.GetString(x);

            //var output = st(result.ToArray());
            var review = _context.Reviews.Where(item => item.ProductId == id).ToList().Last();
            var python = @"C:\Users\User\AppData\Local\Programs\Python\Python39\python.exe";
            var script = @"C:\Users\User\OneDrive\DaysBetweenDates.py";

            var process = new Process();
            process.StartInfo = new ProcessStartInfo(python, script+" \""+review.Text+"\"")
            {
                //Arguments = " \"null\"",
                UseShellExecute = false,
            CreateNoWindow = true,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
        };
            process.Start();

            string output = process.StandardOutput.ReadToEnd();
            review.Sentiment = output;
            _context.SaveChanges();
            process.WaitForExit();
            //string sentiment = "null";

            //psi.Arguments = $"\"{script}\" \"{sentiment}\"";

            


            //var results = "";
            //var errors = "";
            ////using(var process = Process.Start(psi))
            ////{
            //psi.start
            //    results = process.StandardOutput.ReadToEnd();
            //    errors = process.StandardError.ReadToEnd();
            ////}
            //var output = results;
            //var input = errors;

            //Console.WriteLine("Results:");
            //Console.WriteLine(st(result.ToArray()));


            var posts = _context.Reviews.Where(item=>item.ProductId==id).ToList();
            return View(posts);
        }
        //[HttpPost]
        //public IActionResult ProductInfo(string name)
        //{
        //    var line = _context.Products.Include(p => p.Manufacturer).Where(line => line.Name == name).FirstOrDefault();
        //    if (line == null) return RedirectToAction("Index");
        //    return View(line);
        //}
    }
}
