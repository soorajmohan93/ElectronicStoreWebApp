using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElectronicStoreModels.Models
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }

        [ForeignKey("Products"), Display(Name = "Product", Description = "Product")]
        public int Product { get; set; }

        [ForeignKey("Customers"), Display(Name = "Customer", Description = "Customer")]
        public int Customer { get; set; }

        public Product Products { get; set; }

        public Customer Customers { get; set; }
    }
}
