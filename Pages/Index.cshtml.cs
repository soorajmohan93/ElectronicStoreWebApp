using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElectronicStoreWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ElectronicStoreWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public List<Product> products { get; set; }
        public List<ProductCategory> categories { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            //categories = new List<ProductCategory>();
            //categories.Add(new ProductCategory() { CategoryName = "Laptop" });
            products = new List<Product>();
            products.Add(new Product() { ProductId = 1, ProductName = "MacBook Pro 13inch", ProductDesc = "13 inch laptop from Apple", ProductPrice = 1799.00M, ProductCategory = new ProductCategory() { CategoryName = "Laptop" } });
            products.Add(new Product() { ProductId = 12, ProductName = "Iphone 13", ProductDesc = "Phone from Apple", ProductPrice = 999.00M, ProductCategory = new ProductCategory() { CategoryName = "Mobile Phone" } });
        }
    }
}
