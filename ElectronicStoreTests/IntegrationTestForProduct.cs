using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace ElectronicStoreTests
{
    [TestClass]
    public class IntegrationTestForProduct
    {
        private IWebDriver _webDriver;

        [TestInitialize]
        public void Startup()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            _webDriver = new ChromeDriver();
        }

        [TestMethod]
        public void HomePage_NavigateHome_NavigateProduct()
        {
            _webDriver.Navigate().GoToUrl("http://localhost:21177");
            _webDriver.FindElements(By.CssSelector("a.nav-link.text-dark"))[2].Click();
            Assert.IsTrue(_webDriver.Title.Contains("Maintain Products"));
        }

        [TestMethod]
        public void HomePage_NavigateHome_NavigateProduct_SearchProduct()
        {
            _webDriver.Navigate().GoToUrl("http://localhost:21177");
            _webDriver.FindElements(By.CssSelector("a.nav-link.text-dark"))[2].Click();
            var input = _webDriver.FindElement(By.CssSelector("input[name='ProductName']"));
            input.SendKeys("Test");
            _webDriver.FindElement(By.CssSelector("input.filter-clickable")).Click();
            Assert.AreEqual("Search Result for Test", _webDriver.FindElement(By.CssSelector("div.search-result")).Text);
        }

        [TestMethod]
        public void HomePage_NavigateHome_NavigateProduct_NavigateCreateProduct()
        {
            _webDriver.Navigate().GoToUrl("http://localhost:21177");
            _webDriver.FindElements(By.CssSelector("a.nav-link.text-dark"))[2].Click();
            _webDriver.FindElement(By.CssSelector("a.create-new-clickable")).Click();
            Assert.IsTrue(_webDriver.Title.Contains("Create Product"));
        }

        [TestMethod]
        public void HomePage_NavigateHome_NavigateProduct_NavigateEditProduct()
        {
            _webDriver.Navigate().GoToUrl("http://localhost:21177");
            _webDriver.FindElements(By.CssSelector("a.nav-link.text-dark"))[2].Click();
            _webDriver.FindElement(By.CssSelector("a.edit-clickable")).Click();
            Assert.IsTrue(_webDriver.Title.Contains("Edit Product"));
        }

        [TestMethod]
        public void HomePage_NavigateHome_NavigateProduct_NavigateDeleteProduct()
        {
            _webDriver.Navigate().GoToUrl("http://localhost:21177");
            _webDriver.FindElements(By.CssSelector("a.nav-link.text-dark"))[2].Click();
            _webDriver.FindElement(By.CssSelector("a.delete-clickable")).Click();
            Assert.IsTrue(_webDriver.Title.Contains("Delete Product"));
        }

        [TestMethod]
        public void HomePage_NavigateHome_NavigateProduct_NavigateProductDetails()
        {
            _webDriver.Navigate().GoToUrl("http://localhost:21177");
            _webDriver.FindElements(By.CssSelector("a.nav-link.text-dark"))[2].Click();
            _webDriver.FindElement(By.CssSelector("a.details-clickable")).Click();
            Assert.IsTrue(_webDriver.Title.Contains("Product Details"));
        }

        [TestMethod]
        public void HomePage_NavigateHome_NavigateProduct_CreateProduct()
        {
            _webDriver.Navigate().GoToUrl("http://localhost:21177");
            _webDriver.FindElements(By.CssSelector("a.nav-link.text-dark"))[2].Click();
            _webDriver.FindElement(By.CssSelector("a.create-new-clickable")).Click();
            var input = _webDriver.FindElement(By.CssSelector("input[name='ProductName']"));
            input.SendKeys("Testing Product");
            input = _webDriver.FindElement(By.CssSelector("input[name='ProductDesc']"));
            input.SendKeys("Testing Product Description");
            input = _webDriver.FindElement(By.CssSelector("input[name='ProductPrice']"));
            input.SendKeys("0.00");
            input = _webDriver.FindElement(By.CssSelector("input[name='ProductStock']"));
            input.SendKeys("0.00");
            _webDriver.FindElement(By.CssSelector("input.btn.btn-primary")).Click();
            Assert.IsTrue(_webDriver.Title.Contains("Log in - ESA"));
        }

        [TestCleanup]
        public void TearDown()
        {
            _webDriver.Quit();
        }
    }
}
