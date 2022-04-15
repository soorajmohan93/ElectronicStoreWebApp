﻿using System;
using System.Collections.Generic;
using ElectronicStoreModels.Models;

namespace ElectronicStoreMVC.Models
{
    public class IndexViewModel
    {
        public IEnumerable<ProductCategory> ProductCategories { get; set; }

        public IEnumerable<Product> Products { get; set; }
    }
}
