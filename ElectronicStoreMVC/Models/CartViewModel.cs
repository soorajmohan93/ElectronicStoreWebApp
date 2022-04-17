using System;
using System.Collections;
using System.Collections.Generic;
using ElectronicStoreModels.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ElectronicStoreMVC.Models
{
    public class CartViewModel
    {
        public Product product { get; set; }
        public Customer customer { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Customer { get; set; }

        public IEnumerable<Cart> Carts { get; set; }
    }
}
