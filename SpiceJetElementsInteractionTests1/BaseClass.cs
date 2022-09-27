using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using NUnit.Framework;
using Allure.Commons;
using OpenQA.Selenium.Firefox;
using NUnit.Allure.Core;
using SpiceJetElementsInteractionTests1.PageObject;

namespace SpiceJetElementsInteractionTests1
{
    public class BaseClass
    {
        protected IWebDriver _webDriver;
        String url = "https://www.spicejet.com/";
        LoginPageObject loginPageObject = new LoginPageObject();

        [SetUp]
        protected void Setup() {
            //_webDriver = new ChromeDriver();
            _webDriver = new FirefoxDriver();
            //new DriverManager().SetUpDriver(new ChromeConfig());
            new DriverManager().SetUpDriver(new FirefoxConfig());
            Environment.CurrentDirectory = Path.GetDirectoryName(GetType().Assembly.Location);
            _webDriver.Navigate().GoToUrl(url);
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _webDriver.Manage().Window.Maximize();
        }

        [TearDown]
        protected void OneTimeAfter()
        {
            _webDriver.Quit();
        }
    }
}
