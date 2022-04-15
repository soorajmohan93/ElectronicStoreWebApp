using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ElectronicStoreModels.Models
{
    public class ProductCategory
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [Display(Name = "Category of Products", Description = "Category of the Product")]
        public string CategoryName { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
