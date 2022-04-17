using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;


namespace ElectronicStoreTests
{
    [TestClass]
    public class IntegrationTestForIndexPage
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


        [TestCleanup]
        public void TearDown()
        {
            _webDriver.Quit();
        }
    }
}
