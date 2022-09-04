using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using NUnit.Framework;
using Allure.Commons;
using OpenQA.Selenium.Firefox;

namespace SpiceJetElementsInteractionTests1
{
    public class BaseClass
    {
        protected IWebDriver _webDriver;

        [OneTimeSetUp]
        protected void DoBeforeAllTests()
        {
            //_webDriver = new ChromeDriver();
            _webDriver = new FirefoxDriver();
            //new DriverManager().SetUpDriver(new ChromeConfig());
            new DriverManager().SetUpDriver(new FirefoxConfig());
            Environment.CurrentDirectory = Path.GetDirectoryName(GetType().Assembly.Location);
            AllureLifecycle.Instance.CleanupResultDirectory();
        }

        [TearDown]
        protected void OneTimeAfter()
        {
             _webDriver.Quit();
        }

        [SetUp]
        protected void Setup() {
            _webDriver.Manage().Cookies.DeleteAllCookies();
            _webDriver.Navigate().GoToUrl("https://www.spicejet.com/");
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _webDriver.Manage().Window.Maximize();
        }
    }
}
