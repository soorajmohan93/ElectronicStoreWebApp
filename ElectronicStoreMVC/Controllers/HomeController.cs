using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ElectronicStoreMVC.Models;
using ElectronicStoreModels.Models;

namespace ElectronicStoreMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ElectronicStoreContext DbContext;

        public HomeController(ILogger<HomeController> logger, ElectronicStoreContext context)
        {
            _logger = logger;
            DbContext = context;
        }

        public IList<ProductCategory> ProductCategories { get; set; }
        public IList<Product> Products { get; set; }

        public IActionResult Index()
        {
            ProductCategories = DbContext.ProductCategory.ToList();
            Products = DbContext.Product.ToList();
            return View(new IndexViewModel() { ProductCategories = ProductCategories, Products = Products });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
