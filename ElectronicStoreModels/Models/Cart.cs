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

        [Required]
        [Display(Name = "Quantity of Product in Cart", Description = "Quantity of Product in Cart")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Quantity should be greater than 0.")]
        public int CartQuantity { get; set; }

        public Product Products { get; set; }

        public Customer Customers { get; set; }
    }
}
