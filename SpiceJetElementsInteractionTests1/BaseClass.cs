using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using NUnit.Framework;
using Allure.Commons;
using OpenQA.Selenium.Firefox;
using NUnit.Allure.Core;

namespace SpiceJetElementsInteractionTests1
{
    public class BaseClass
    {
        protected IWebDriver _webDriver;

        [SetUp]
        protected void Setup() {
            //_webDriver = new ChromeDriver();
            _webDriver = new FirefoxDriver();
            //new DriverManager().SetUpDriver(new ChromeConfig());
            new DriverManager().SetUpDriver(new FirefoxConfig());
            Environment.CurrentDirectory = Path.GetDirectoryName(GetType().Assembly.Location);
            _webDriver.Navigate().GoToUrl("https://www.spicejet.com/");
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(12);
            _webDriver.Manage().Window.Maximize();
        }

        [TearDown]
        protected void OneTimeAfter()
        {
            _webDriver.Quit();
        }
    }
}
