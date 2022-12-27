using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using System.Reflection;

namespace SpiceJetElementsInteractionTests1
{
    public class BaseClass
    {
        protected IWebDriver _webDriver;
        string url = "https://www.spicejet.com/";

        [SetUp]
        protected void Setup() {
            
            _webDriver = new ChromeDriver();
            //_webDriver = new FirefoxDriver();
            new DriverManager().SetUpDriver(new ChromeConfig());
            //new DriverManager().SetUpDriver(new FirefoxConfig());
            _webDriver.Navigate().GoToUrl(url);
            _webDriver.Manage().Cookies.DeleteAllCookies();
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(40);
            _webDriver.Manage().Window.Maximize();
        }

        [TearDown]
        protected void OneTimeAfter()
        {
            _webDriver.Quit();
        }
    }
}
