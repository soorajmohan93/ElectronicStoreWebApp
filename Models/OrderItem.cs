using System;
namespace ElectronicStoreWebApp.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }

        public String OrderItemName { get; set; }

        public int OrderItemQty { get; set; }

        public decimal OrderItemValue { get; set; }

        public Order OrderId { get; set; }
    }
}
