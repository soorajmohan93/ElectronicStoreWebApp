using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace ElectronicStoreTests
{
    [TestClass]
    public class InegrationTestForCart
    {
        private IWebDriver _webDriver;

        [TestInitialize]
        public void Startup()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            _webDriver = new ChromeDriver();
        }

        [TestMethod]
        public void HomePage_NavigateHome_NavigateCart()
        {
            _webDriver.Navigate().GoToUrl("http://localhost:21177");
            _webDriver.FindElements(By.CssSelector("a.nav-link.text-dark"))[4].Click();
            Assert.IsTrue(_webDriver.Title.Contains("Maintain Cart"));
        }

        [TestMethod]
        public void HomePage_NavigateHome_NavigateCart_NavigateCreateCart()
        {
            _webDriver.Navigate().GoToUrl("http://localhost:21177");
            _webDriver.FindElements(By.CssSelector("a.nav-link.text-dark"))[4].Click();
            _webDriver.FindElement(By.CssSelector("a.create-new-clickable")).Click();
            Assert.IsTrue(_webDriver.Title.Contains("Create Cart Item"));
        }

        [TestMethod]
        public void HomePage_NavigateHome_NavigateCart_NavigateEditCart()
        {
            _webDriver.Navigate().GoToUrl("http://localhost:21177");
            _webDriver.FindElements(By.CssSelector("a.nav-link.text-dark"))[4].Click();
            _webDriver.FindElement(By.CssSelector("a.edit-clickable")).Click();
            Assert.IsTrue(_webDriver.Title.Contains("Edit Cart Item"));
        }

        [TestMethod]
        public void HomePage_NavigateHome_NavigateCart_NavigateDeleteCart()
        {
            _webDriver.Navigate().GoToUrl("http://localhost:21177");
            _webDriver.FindElements(By.CssSelector("a.nav-link.text-dark"))[4].Click();
            _webDriver.FindElement(By.CssSelector("a.delete-clickable")).Click();
            Assert.IsTrue(_webDriver.Title.Contains("Delete Cart Item"));
        }

        [TestMethod]
        public void HomePage_NavigateHome_NavigateCart_NavigateCartDetails()
        {
            _webDriver.Navigate().GoToUrl("http://localhost:21177");
            _webDriver.FindElements(By.CssSelector("a.nav-link.text-dark"))[4].Click();
            _webDriver.FindElement(By.CssSelector("a.details-clickable")).Click();
            Assert.IsTrue(_webDriver.Title.Contains("Cart Item Details"));
        }

        [TestCleanup]
        public void TearDown()
        {
            _webDriver.Quit();
        }
    }
}
