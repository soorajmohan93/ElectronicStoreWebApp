using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace ElectronicStoreTests
{
    [TestClass]
    public class IntegrationTestForIdentity
    {
        private IWebDriver _webDriver;

        [TestInitialize]
        public void Startup()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            _webDriver = new ChromeDriver();
        }

        [TestMethod]
        public void HomePage_NavigateHome_NavigateProduct_IdentityRegister()
        {
            _webDriver.Navigate().GoToUrl("http://localhost:21177");
            _webDriver.FindElements(By.CssSelector("a.nav-link.text-dark"))[5].Click();
            Assert.IsTrue(_webDriver.Title.Contains("Register - ESA"));
        }

        [TestMethod]
        public void HomePage_NavigateHome_NavigateProduct_IdentityLogin()
        {
            _webDriver.Navigate().GoToUrl("http://localhost:21177");
            _webDriver.FindElements(By.CssSelector("a.nav-link.text-dark"))[6].Click();
            Assert.IsTrue(_webDriver.Title.Contains("Log in - ESA"));
        }

        [TestCleanup]
        public void TearDown()
        {
            _webDriver.Quit();
        }
    }
}
