using System;
using System.Collections.Generic;
using ElectronicStoreModels.Models;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicStoreMVC.Models
{
    public class ProductViewModel
    {
        [BindProperty(SupportsGet = true)]
        public string ProductName { get; set; }

        public IEnumerable<Product> Products { get; set; }
    }
}
