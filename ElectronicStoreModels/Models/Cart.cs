using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElectronicStoreModels.Models
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }

        [Required]
        [ForeignKey("Products"), Display(Name = "Select Product", Description = "Select Product")]
        public int Product { get; set; }

        [Required]
        [ForeignKey("Customers"), Display(Name = "Select Customer", Description = "Select Customer")]
        public int Customer { get; set; }

        public Product Products { get; set; }

        public Customer Customers { get; set; }
    }
}
