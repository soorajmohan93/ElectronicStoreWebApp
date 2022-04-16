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
        public void HomePage_NavigateHome_NavigateProduct_NavigateCreateProductCategory()
        {
            _webDriver.Navigate().GoToUrl("http://localhost:21177");
            _webDriver.FindElements(By.CssSelector("a.nav-link.text-dark"))[1].Click();
            _webDriver.FindElement(By.CssSelector("a.create-new-clickable")).Click();
            Assert.IsTrue(_webDriver.Title.Contains("Create Product Category"));
        }

        [TestMethod]
        public void HomePage_NavigateHome_NavigateProduct_NavigateEditProductCategory()
        {
            _webDriver.Navigate().GoToUrl("http://localhost:21177");
            _webDriver.FindElements(By.CssSelector("a.nav-link.text-dark"))[1].Click();
            _webDriver.FindElement(By.CssSelector("a.edit-clickable")).Click();
            Assert.IsTrue(_webDriver.Title.Contains("Edit Product Category"));
        }

        [TestMethod]
        public void HomePage_NavigateHome_NavigateProduct_NavigateDeleteProductCategory()
        {
            _webDriver.Navigate().GoToUrl("http://localhost:21177");
            _webDriver.FindElements(By.CssSelector("a.nav-link.text-dark"))[1].Click();
            _webDriver.FindElement(By.CssSelector("a.delete-clickable")).Click();
            Assert.IsTrue(_webDriver.Title.Contains("Delete Product Category"));
        }

        [TestMethod]
        public void HomePage_NavigateHome_NavigateProduct_NavigateProductCategoryDetails()
        {
            _webDriver.Navigate().GoToUrl("http://localhost:21177");
            _webDriver.FindElements(By.CssSelector("a.nav-link.text-dark"))[1].Click();
            _webDriver.FindElement(By.CssSelector("a.details-clickable")).Click();
            Assert.IsTrue(_webDriver.Title.Contains("Product Category Details"));
        }

        [TestMethod]
        public void HomePage_NavigateHome_NavigateProduct_CreateProductCategory()
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

        [TestMethod]
        public void HomePage_NavigateHome_NavigateProduct_IdentityRegister()
        {
            _webDriver.Navigate().GoToUrl("http://localhost:21177");
            _webDriver.FindElements(By.CssSelector("a.nav-link.text-dark"))[3].Click();
            Assert.IsTrue(_webDriver.Title.Contains("Register - ESA"));
        }

        [TestMethod]
        public void HomePage_NavigateHome_NavigateProduct_IdentityLogin()
        {
            _webDriver.Navigate().GoToUrl("http://localhost:21177");
            _webDriver.FindElements(By.CssSelector("a.nav-link.text-dark"))[4].Click();
            Assert.IsTrue(_webDriver.Title.Contains("Log in - ESA"));
        }

        [TestCleanup]
        public void TearDown()
        {
            _webDriver.Quit();
        }
    }
}
