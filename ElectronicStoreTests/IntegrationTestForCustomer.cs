using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace ElectronicStoreTests
{
    [TestClass]
    public class IntegrationTestForCustomer
    {
        private IWebDriver _webDriver;

        [TestInitialize]
        public void Startup()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            _webDriver = new ChromeDriver();
        }

        [TestMethod]
        public void HomePage_NavigateHome_NavigateCustomer()
        {
            _webDriver.Navigate().GoToUrl("http://localhost:21177");
            _webDriver.FindElements(By.CssSelector("a.nav-link.text-dark"))[2].Click();
            Assert.IsTrue(_webDriver.Title.Contains("Maintain Customers"));
        }

        [TestMethod]
        public void HomePage_NavigateHome_NavigateCustomer_NavigateCreateCustomer()
        {
            _webDriver.Navigate().GoToUrl("http://localhost:21177");
            _webDriver.FindElements(By.CssSelector("a.nav-link.text-dark"))[2].Click();
            _webDriver.FindElement(By.CssSelector("a.create-new-clickable")).Click();
            Assert.IsTrue(_webDriver.Title.Contains("Create Customer"));
        }

        [TestMethod]
        public void HomePage_NavigateHome_NavigateCustomer_NavigateEditCustomer()
        {
            _webDriver.Navigate().GoToUrl("http://localhost:21177");
            _webDriver.FindElements(By.CssSelector("a.nav-link.text-dark"))[2].Click();
            _webDriver.FindElement(By.CssSelector("a.edit-clickable")).Click();
            Assert.IsTrue(_webDriver.Title.Contains("Edit Customer"));
        }

        [TestMethod]
        public void HomePage_NavigateHome_NavigateCustomer_NavigateDeleteCustomer()
        {
            _webDriver.Navigate().GoToUrl("http://localhost:21177");
            _webDriver.FindElements(By.CssSelector("a.nav-link.text-dark"))[2].Click();
            _webDriver.FindElement(By.CssSelector("a.delete-clickable")).Click();
            Assert.IsTrue(_webDriver.Title.Contains("Delete Customer"));
        }

        [TestMethod]
        public void HomePage_NavigateHome_NavigateCustomer_NavigateCustomerDetails()
        {
            _webDriver.Navigate().GoToUrl("http://localhost:21177");
            _webDriver.FindElements(By.CssSelector("a.nav-link.text-dark"))[2].Click();
            _webDriver.FindElement(By.CssSelector("a.details-clickable")).Click();
            Assert.IsTrue(_webDriver.Title.Contains("Customer Details"));
        }

        [TestMethod]
        public void HomePage_NavigateHome_NavigateCustomer_CreateCustomer()
        {
            _webDriver.Navigate().GoToUrl("http://localhost:21177");
            _webDriver.FindElements(By.CssSelector("a.nav-link.text-dark"))[2].Click();
            _webDriver.FindElement(By.CssSelector("a.create-new-clickable")).Click();
            var input = _webDriver.FindElement(By.CssSelector("input[name='CustomerName']"));
            input.SendKeys("Testing Customer");
            input = _webDriver.FindElement(By.CssSelector("input[name='CustomerAddress']"));
            input.SendKeys("Testing Address");
            input = _webDriver.FindElement(By.CssSelector("input[name='PhoneNumber']"));
            input.SendKeys("1234567890");
            input = _webDriver.FindElement(By.CssSelector("input[name='CustomerEmail']"));
            input.SendKeys("testcustomer@test.ca");
            _webDriver.FindElement(By.CssSelector("input.btn.btn-primary")).Click();
            Assert.IsTrue(_webDriver.Title.Contains("Log in - ESA"));
        }

        [TestMethod]
        public void HomePage_NavigateHome_NavigateCustomer_CreateBlankCustomer()
        {
            _webDriver.Navigate().GoToUrl("http://localhost:21177");
            _webDriver.FindElements(By.CssSelector("a.nav-link.text-dark"))[2].Click();
            _webDriver.FindElement(By.CssSelector("a.create-new-clickable")).Click();
            _webDriver.FindElement(By.CssSelector("input.btn.btn-primary")).Click();
            Assert.AreEqual("The Name of Customer field is required.", _webDriver.FindElements(By.CssSelector("span.text-danger"))[0].Text);
            Assert.AreEqual("The Customer Phone Number field is required.", _webDriver.FindElements(By.CssSelector("span.text-danger"))[2].Text);
            Assert.AreEqual("The Email ID of Customer field is required.", _webDriver.FindElements(By.CssSelector("span.text-danger"))[3].Text);
        }

        [TestMethod]
        public void HomePage_NavigateHome_NavigateCustomer_CreateCustomerWithInvalidData()
        {
            _webDriver.Navigate().GoToUrl("http://localhost:21177");
            _webDriver.FindElements(By.CssSelector("a.nav-link.text-dark"))[2].Click();
            _webDriver.FindElement(By.CssSelector("a.create-new-clickable")).Click();
            var input = _webDriver.FindElement(By.CssSelector("input[name='PhoneNumber']")); ;
            input.SendKeys("Test");
            input = _webDriver.FindElement(By.CssSelector("input[name='CustomerEmail']"));
            input.SendKeys("test");
            _webDriver.FindElement(By.CssSelector("input.btn.btn-primary")).Click();
            Assert.AreEqual("Invalid Mobile Number. Enter 10 digit Phone Number.", _webDriver.FindElements(By.CssSelector("span.text-danger"))[2].Text);
            Assert.AreEqual("The Email ID of Customer field is not a valid e-mail address.", _webDriver.FindElements(By.CssSelector("span.text-danger"))[3].Text);
        }


        [TestMethod]
        public void HomePage_NavigateHome_NavigateCustomer_EditBlankCustomer()
        {
            _webDriver.Navigate().GoToUrl("http://localhost:21177");
            _webDriver.FindElements(By.CssSelector("a.nav-link.text-dark"))[2].Click();
            _webDriver.FindElement(By.CssSelector("a.edit-clickable")).Click();
            var input = _webDriver.FindElement(By.CssSelector("input[name='CustomerName']"));
            input.Clear();
            input = _webDriver.FindElement(By.CssSelector("input[name='CustomerAddress']"));
            input.Clear();
            input = _webDriver.FindElement(By.CssSelector("input[name='PhoneNumber']"));
            input.Clear();
            input = _webDriver.FindElement(By.CssSelector("input[name='CustomerEmail']"));
            input.Clear();
            _webDriver.FindElement(By.CssSelector("input.btn.btn-primary")).Click();
            Assert.AreEqual("The Name of Customer field is required.", _webDriver.FindElements(By.CssSelector("span.text-danger"))[0].Text);
            Assert.AreEqual("The Customer Phone Number field is required.", _webDriver.FindElements(By.CssSelector("span.text-danger"))[2].Text);
            Assert.AreEqual("The Email ID of Customer field is required.", _webDriver.FindElements(By.CssSelector("span.text-danger"))[3].Text);
        }

        [TestMethod]
        public void HomePage_NavigateHome_NavigateCustomer_EditInvalidCustomer()
        {
            _webDriver.Navigate().GoToUrl("http://localhost:21177");
            _webDriver.FindElements(By.CssSelector("a.nav-link.text-dark"))[2].Click();
            _webDriver.FindElement(By.CssSelector("a.edit-clickable")).Click();
            var input = _webDriver.FindElement(By.CssSelector("input[name='PhoneNumber']"));
            input.Clear();
            input.SendKeys("Test");
            input = _webDriver.FindElement(By.CssSelector("input[name='CustomerEmail']"));
            input.Clear();
            input.SendKeys("test");
            _webDriver.FindElement(By.CssSelector("input.btn.btn-primary")).Click();
            Assert.AreEqual("Invalid Mobile Number. Enter 10 digit Phone Number.", _webDriver.FindElements(By.CssSelector("span.text-danger"))[2].Text);
            Assert.AreEqual("The Email ID of Customer field is not a valid e-mail address.", _webDriver.FindElements(By.CssSelector("span.text-danger"))[3].Text);
        }


        [TestCleanup]
        public void TearDown()
        {
            _webDriver.Quit();
        }
    }
}
