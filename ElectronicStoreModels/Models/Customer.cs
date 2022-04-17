using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ElectronicStoreModels.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        [Display(Name = "Name of Customer", Description = "Name of Customer")]
        public string CustomerName { get; set; }

        [Display(Name = "Customer Address", Description = "Customer Address")]
        public string CustomerAddress { get; set; }

        [Required]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number. Enter 10 digit Phone Number.")]
        [Display(Name = "Customer Phone Number", Description = "Customer Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email ID of Customer", Description = "Email ID of Customer")]
        public string CustomerEmail { get; set; }

        public ICollection<Cart> Carts { get; set; }
    }
}
