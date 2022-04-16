using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;


namespace ElectronicStoreTests
{
    [TestClass]
    public class IntegrationTests
    {

        private IWebDriver _webDriver;

        [TestInitialize]
        public void Startup()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            _webDriver = new ChromeDriver();
        }


        [TestMethod]
        public void HomePage_Navigate_CheckTitleForName()
        {
            _webDriver.Navigate().GoToUrl("http://localhost:21177");
            Assert.IsTrue(_webDriver.Title.Contains("Electronics Store"));
        }

        [TestMethod]
        public void HomePage_NavigateHome_NavigateProductCategory()
        {
            _webDriver.Navigate().GoToUrl("http://localhost:21177");
            _webDriver.FindElements(By.CssSelector("a.nav-link.text-dark"))[1].Click();
            Assert.IsTrue(_webDriver.Title.Contains("Maintain Category"));
        }

        [TestMethod]
        public void HomePage_NavigateHome_NavigateProduct()
        {
            _webDriver.Navigate().GoToUrl("http://localhost:21177");
            _webDriver.FindElements(By.CssSelector("a.nav-link.text-dark"))[2].Click();
            Assert.IsTrue(_webDriver.Title.Contains("Maintain Products"));
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

        [TestCleanup]
        public void TearDown()
        {
            _webDriver.Quit();
        }
    }
}
