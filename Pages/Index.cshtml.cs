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
            products.Add(new Product() { ProductId = 1, ProductName = "Apple MacBook Pro 13", ProductPrice = 1899.00M, ProductCategory = new ProductCategory() { CategoryName = "Laptops" }, ProductDesc = "13 inch laptop with M1 Silicon chip" });
            products.Add(new Product() { ProductId = 2, ProductName = "Apple MacBook Pro 14", ProductPrice = 2199.00M, ProductCategory = new ProductCategory() { CategoryName = "Laptops" }, ProductDesc = "14 inch laptop with M1 Silicon chip" });
            products.Add(new Product() { ProductId = 3, ProductName = "Apple MacBook Pro 16", ProductPrice = 2399.00M, ProductCategory = new ProductCategory() { CategoryName = "Laptops" }, ProductDesc = "16 inch laptop with M1 Silicon chip" });
            products.Add(new Product() { ProductId = 4, ProductName = "Apple Mac", ProductPrice = 1799.00M, ProductCategory = new ProductCategory() { CategoryName = "Desktops" }, ProductDesc = "Apple Mac with M1 Silicon chip" });
            products.Add(new Product() { ProductId = 5, ProductName = "Lenovo ThinkCentre", ProductPrice = 1099.00M, ProductCategory = new ProductCategory() { CategoryName = "Desktops" }, ProductDesc = "Levono PC" });
            products.Add(new Product() { ProductId = 6, ProductName = "Dell Desktop Computer", ProductPrice = 1299.00M, ProductCategory = new ProductCategory() { CategoryName = "Desktops" }, ProductDesc = "Dell PC" });
            products.Add(new Product() { ProductId = 7, ProductName = "IPhone 13 Pro", ProductPrice = 1000.00M, ProductCategory = new ProductCategory() { CategoryName = "Mobile Phones" }, ProductDesc = "Apple Phone" });
            products.Add(new Product() { ProductId = 8, ProductName = "Samsung Galaxy S22", ProductPrice = 899.00M, ProductCategory = new ProductCategory() { CategoryName = "Mobile Phones" }, ProductDesc = "Samsung Phone" });
            products.Add(new Product() { ProductId = 9, ProductName = "OnePlus 10 Pro", ProductPrice = 799.00M, ProductCategory = new ProductCategory() { CategoryName = "Mobile Phones" }, ProductDesc = "OnePlus Phone" });
            products.Add(new Product() { ProductId = 10, ProductName = "Sony PS5", ProductPrice = 1200.00M, ProductCategory = new ProductCategory() { CategoryName = "Gaming Consoles" }, ProductDesc = "Playstation 5 from Sony" });
            products.Add(new Product() { ProductId = 11, ProductName = "Microsoft XBox X", ProductPrice = 1000.00M, ProductCategory = new ProductCategory() { CategoryName = "Gaming Consoles" }, ProductDesc = "Latest Xbox console" });
            products.Add(new Product() { ProductId = 12, ProductName = "Nintendo Switch", ProductPrice = 899.00M, ProductCategory = new ProductCategory() { CategoryName = "Gaming Consoles" }, ProductDesc = "Portable console" });
            products.Add(new Product() { ProductId = 13, ProductName = "Sony WH-1000XM4", ProductPrice = 348.00M, ProductCategory = new ProductCategory() { CategoryName = "Accessories" }, ProductDesc = "Sony Headphones" });
            products.Add(new Product() { ProductId = 14, ProductName = "Bose QuietComfort 45", ProductPrice = 379.00M, ProductCategory = new ProductCategory() { CategoryName = "Accessories" }, ProductDesc = "Noise Cancelling Headphones from Bose" });
            products.Add(new Product() { ProductId = 15, ProductName = "Apple Watch Series 3", ProductPrice = 249.00M, ProductCategory = new ProductCategory() { CategoryName = "Accessories" }, ProductDesc = "Aluminium Case with Black Sport Band" });
        }
    }
}
