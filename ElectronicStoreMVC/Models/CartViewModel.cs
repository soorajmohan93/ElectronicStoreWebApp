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
        //To filter cart list with customer
        [BindProperty(SupportsGet = true)]
        public string Customer { get; set; }

        public IEnumerable<Cart> Carts { get; set; }
    }
}
