using System;
using System.Diagnostics.Contracts;

namespace ElectronicStoreModels
{
    public class Calculations
    {
        public static decimal TotalPrice(decimal price, int quantity)
        {
            return price * quantity;
        }

        public static int RemainingQuantity(int totalQuantity, int SelectedQuantity)
        {
            return totalQuantity - SelectedQuantity;
        }
    }
}
