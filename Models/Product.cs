using System;
namespace ElectronicStoreWebApp.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public ProductCategory ProductCategory { get; set; }

        public string ProductDesc { get; set; }

        public decimal ProductPrice { get; set; }
    }
}
