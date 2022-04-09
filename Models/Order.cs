using System;
using System.Collections.Generic;

namespace ElectronicStoreWebApp.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public decimal OrderValue { get; set; }

        ICollection<OrderItem> OrderItems { get; set; }
    }
}
