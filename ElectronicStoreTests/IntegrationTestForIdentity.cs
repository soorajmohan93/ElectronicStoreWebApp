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
        public void HomePage_NavigateHome_NavigateProduct_NavigateIdentityRegister()
        {
            _webDriver.Navigate().GoToUrl("http://localhost:21177");
            _webDriver.FindElements(By.CssSelector("a.nav-link.text-dark"))[5].Click();
            Assert.IsTrue(_webDriver.Title.Contains("Register - ESA"));
        }

        [TestMethod]
        public void HomePage_NavigateHome_NavigateProduct_NavigateIdentityLogin()
        {
            _webDriver.Navigate().GoToUrl("http://localhost:21177");
            _webDriver.FindElements(By.CssSelector("a.nav-link.text-dark"))[6].Click();
            Assert.IsTrue(_webDriver.Title.Contains("Log in - ESA"));
        }

        [TestMethod]
        public void HomePage_NavigateHome_NavigateProduct_IdentityLogin_InvalidLogin()
        {
            _webDriver.Navigate().GoToUrl("http://localhost:21177");
            _webDriver.FindElements(By.CssSelector("a.nav-link.text-dark"))[6].Click();
            Assert.IsTrue(_webDriver.Title.Contains("Log in - ESA"));
            var input = _webDriver.FindElement(By.CssSelector("input[name='Input.UserName']"));
            input.SendKeys("WrongUser");
            input = _webDriver.FindElement(By.CssSelector("input[name='Input.Password']"));
            input.SendKeys("WrongPassword");
            _webDriver.FindElement(By.CssSelector("button.btn.btn-primary")).Click();
            Assert.AreEqual("Invalid login attempt.", _webDriver.FindElement(By.CssSelector("div.text-danger")).Text);
        }

        [TestCleanup]
        public void TearDown()
        {
            _webDriver.Quit();
        }
    }
}
