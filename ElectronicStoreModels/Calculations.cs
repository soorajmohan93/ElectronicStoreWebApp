using System;
using System.Diagnostics.Contracts;

namespace ElectronicStoreModels
{
    public class Calculations
    {
        public decimal TotalPrice(decimal price, int quantity)
        {
            return price * quantity;
        }

        public decimal RemainingQunatity(int totalQuantity, int SelectedQuantity)
        {
            return totalQuantity - SelectedQuantity;
        }
    }
}
