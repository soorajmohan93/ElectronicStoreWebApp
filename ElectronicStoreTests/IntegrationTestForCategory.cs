using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace ElectronicStoreTests
{
    [TestClass]
    public class IntegrationTestForCategory
    {
        private IWebDriver _webDriver;

        [TestInitialize]
        public void Startup()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            _webDriver = new ChromeDriver();
        }

        [TestMethod]
        public void HomePage_NavigateHome_NavigateCategory()
        {
            _webDriver.Navigate().GoToUrl("http://localhost:21177");
            _webDriver.FindElements(By.CssSelector("a.nav-link.text-dark"))[1].Click();
            Assert.IsTrue(_webDriver.Title.Contains("Maintain Category"));
        }


        [TestMethod]
        public void HomePage_NavigateHome_NavigateCategory_NavigateCreateProductCategory()
        {
            _webDriver.Navigate().GoToUrl("http://localhost:21177");
            _webDriver.FindElements(By.CssSelector("a.nav-link.text-dark"))[1].Click();
            _webDriver.FindElement(By.CssSelector("a.create-new-clickable")).Click();
            Assert.IsTrue(_webDriver.Title.Contains("Create Product Category"));
        }

        [TestMethod]
        public void HomePage_NavigateHome_NavigateCategory_NavigateEditProductCategory()
        {
            _webDriver.Navigate().GoToUrl("http://localhost:21177");
            _webDriver.FindElements(By.CssSelector("a.nav-link.text-dark"))[1].Click();
            _webDriver.FindElement(By.CssSelector("a.edit-clickable")).Click();
            Assert.IsTrue(_webDriver.Title.Contains("Edit Product Category"));
        }

        [TestMethod]
        public void HomePage_NavigateHome_NavigateCategory_NavigateDeleteProductCategory()
        {
            _webDriver.Navigate().GoToUrl("http://localhost:21177");
            _webDriver.FindElements(By.CssSelector("a.nav-link.text-dark"))[1].Click();
            _webDriver.FindElement(By.CssSelector("a.delete-clickable")).Click();
            Assert.IsTrue(_webDriver.Title.Contains("Delete Product Category"));
        }

        [TestMethod]
        public void HomePage_NavigateHome_NavigateCategory_NavigateProductCategoryDetails()
        {
            _webDriver.Navigate().GoToUrl("http://localhost:21177");
            _webDriver.FindElements(By.CssSelector("a.nav-link.text-dark"))[1].Click();
            _webDriver.FindElement(By.CssSelector("a.details-clickable")).Click();
            Assert.IsTrue(_webDriver.Title.Contains("Product Category Details"));
        }

        [TestMethod]
        public void HomePage_NavigateHome_NavigateCategory_CreateProductCategory()
        {
            _webDriver.Navigate().GoToUrl("http://localhost:21177");
            _webDriver.FindElements(By.CssSelector("a.nav-link.text-dark"))[1].Click();
            _webDriver.FindElement(By.CssSelector("a.create-new-clickable")).Click();
            var input = _webDriver.FindElement(By.CssSelector("input[name='CategoryName']"));
            input.SendKeys("Testing Category");
            _webDriver.FindElement(By.CssSelector("input.btn.btn-primary")).Click();
            Assert.IsTrue(_webDriver.Title.Contains("Log in - ESA"));
        }


        [TestMethod]
        public void HomePage_NavigateHome_NavigateCategory_CreateBlankProductCategory()
        {
            _webDriver.Navigate().GoToUrl("http://localhost:21177");
            _webDriver.FindElements(By.CssSelector("a.nav-link.text-dark"))[1].Click();
            _webDriver.FindElement(By.CssSelector("a.create-new-clickable")).Click();
            _webDriver.FindElement(By.CssSelector("input.btn.btn-primary")).Click();
            Assert.AreEqual("The Category of Products field is required.", _webDriver.FindElement(By.CssSelector("span.text-danger")).Text);
        }


        [TestCleanup]
        public void TearDown()
        {
            _webDriver.Quit();
        }
    }
}
