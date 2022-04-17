using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElectronicStoreModels.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [Display(Name = "Name of Product", Description = "Name of Product")]
        public string ProductName { get; set; }

        [ForeignKey("ProductCategory"), Display(Name = "Category", Description = "Category of the Product")]
        public int Category { get; set; }

        [Required]
        [Display(Name = "Description of Product", Description = "Description of Product")]
        public string ProductDesc { get; set; }

        [Required]
        [Display(Name = "Price of Product", Description = "Price of Product")]
        public decimal ProductPrice { get; set; }

        [Required]
        [Display(Name = "Quantity of Product in Stock", Description = "Quantity of Product in Stock")]
        [Range(0, Int32.MaxValue)]
        public int ProductStock { get; set; }

        public ProductCategory ProductCategory { get; set; }

        public ICollection<Cart> Carts { get; set; }
    }
}
