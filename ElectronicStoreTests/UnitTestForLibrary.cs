using System;
using ElectronicStoreModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.DevTools.V85.DOM;

namespace ElectronicStoreTests
{
    [TestClass]
    public class UnitTestForLibrary
    {


        [TestMethod]
        public void CalculationTest_TotalPrice()
        {
            Assert.AreEqual(3019.8M, Calculations.TotalPrice(150.99M, 20));
        }

        [TestMethod]
        public void CalculationTest_TotalPrice_withNegatives()
        {
            Assert.AreEqual(4522.50M, Calculations.TotalPrice(-100.50M, -45));
        }

        [TestMethod]
        [DataRow(10, 2)]
        [DataRow(2, 3)]
        public void CalculationTest_TotalPrice_WithoutDecimals(double inPrice, int quantity)
        {
            decimal price = (decimal)inPrice;
            Assert.AreEqual(price*quantity, Calculations.TotalPrice(price, quantity));
        }

        [TestMethod]
        [DataRow(100.99, 2)]
        [DataRow(45.50, 3)]
        public void CalculationTest_TotalPrice_WithDecimalsPrice(double inPrice, int quantity)
        {
            decimal price = (decimal)inPrice;
            Assert.AreEqual(price * quantity, Calculations.TotalPrice(price, quantity));
        }

        [TestMethod]
        [DataRow(-150.99, 2)]
        [DataRow(-76.50, 3)]
        public void CalculationTest_TotalPrice_WithNegativePrice(double inPrice, int quantity)
        {
            decimal price = (decimal)inPrice;
            Assert.AreEqual(price * quantity, Calculations.TotalPrice(price, quantity));
        }

        [TestMethod]
        [DataRow(1200.50, -20)]
        [DataRow(46.00, -4)]
        public void CalculationTest_TotalPrice_WithNegativeQuantity(double inPrice, int quantity)
        {
            decimal price = (decimal)inPrice;
            Assert.AreEqual(price * quantity, Calculations.TotalPrice(price, quantity));
        }

        [TestMethod]
        [DataRow(-759, 20)]
        [DataRow(-41, 4)]
        public void CalculationTest_TotalPrice_WithNegativeIntegerPrice(double inPrice, int quantity)
        {
            decimal price = (decimal)inPrice;
            Assert.AreEqual(price * quantity, Calculations.TotalPrice(price, quantity));
        }

        [TestMethod]
        public void CalculationTest_RemainingQuantity()
        {
            Assert.AreEqual(8, Calculations.RemainingQunatity(20, 12));
        }

        [TestMethod]
        public void CalculationTest_RemainingQuantity_NegativeValue()
        {
            Assert.AreEqual(-10, Calculations.RemainingQunatity(-21, -11));
        }

        [TestMethod]
        [DataRow(23, 10)]
        [DataRow(37, 2)]
        public void CalculationTest_RemainingQuantity_PostiveValues(int totalQuantity, int SelectedQuantity)
        {
            Assert.AreEqual(totalQuantity-SelectedQuantity, Calculations.RemainingQunatity(totalQuantity,SelectedQuantity));
        }

        [TestMethod]
        [DataRow(-678, -140)]
        [DataRow(-355, -244)]
        public void CalculationTest_RemainingQuantity_NegativeValues(int totalQuantity, int SelectedQuantity)
        {
            Assert.AreEqual(totalQuantity - SelectedQuantity, Calculations.RemainingQunatity(totalQuantity, SelectedQuantity));
        }

        [TestMethod]
        [DataRow(-231, 311)]
        [DataRow(-323, 1122)]
        public void CalculationTest_RemainingQuantity_OneNegativeValue_OnePostiveValue(int totalQuantity, int SelectedQuantity)
        {
            Assert.AreEqual(totalQuantity - SelectedQuantity, Calculations.RemainingQunatity(totalQuantity, SelectedQuantity));
        }

        [TestMethod]
        [DataRow(1223, -2642)]
        [DataRow(12, -86)]
        public void CalculationTest_RemainingQuantity_OnePositiveValue_OneNegativeValue(int totalQuantity, int SelectedQuantity)
        {
            Assert.AreEqual(totalQuantity - SelectedQuantity, Calculations.RemainingQunatity(totalQuantity, SelectedQuantity));
        }
    }
}
