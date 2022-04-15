using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;


namespace ElectronicStoreTests
{
    [TestClass]
    public class UnitTest1
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
            //http://localhost:21177
            _webDriver.Navigate().GoToUrl("http://localhost:21177");
            Assert.IsTrue(_webDriver.Title.Contains("Electronics Store"));
        }

        [TestMethod]
        public void HomePage_NavigateHome_NavigateProductCategory()
        {
            //http://localhost:21177
            _webDriver.Navigate().GoToUrl("http://localhost:21177");
            _webDriver.FindElements(By.CssSelector("a.nav-link.text-dark"))[1].Click();
            Assert.IsTrue(_webDriver.Title.Contains("Maintain Category"));
        }

        [TestMethod]
        public void HomePage_NavigateHome_NavigateProduct()
        {
            //http://localhost:21177
            _webDriver.Navigate().GoToUrl("http://localhost:21177");
            _webDriver.FindElements(By.CssSelector("a.nav-link.text-dark"))[2].Click();
            Assert.IsTrue(_webDriver.Title.Contains("Maintain Product"));
        }

        [TestCleanup]
        public void TearDown()
        {
            _webDriver.Quit();
        }
    }
}
