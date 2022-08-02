using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Interactions;
using System.Collections;
using OpenQA.Selenium.Firefox;

//- Used https://github.com/rosolko/WebDriverManager.Net so Firefox browser is working now (+ Chrome)
// automatically downloads browser version and keeps updated


namespace SpiceJetElementsInteractionTests1
{
    public class Tests
    {
        private IWebDriver _webDriver;
        private readonly By _numberOfChildren = By.CssSelector("div[data-testid='Children-testID-plus-one-cta']");

        [SetUp]
        public void Setup()
        {

            _webDriver = new ChromeDriver();
            new DriverManager().SetUpDriver(new ChromeConfig());
            new DriverManager().SetUpDriver(new FirefoxConfig());
            //_webDriver = new FirefoxDriver();
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _webDriver.Navigate().GoToUrl("https://www.spicejet.com/");
            _webDriver.Manage().Window.Maximize();
        }

        [Test]
        public void RoundTripRadioButtonClick()
        {
            // open COVID-19 rules link in new tab // retrieve info 
            _webDriver.FindElement(By.XPath("//div[@data-testid='home-page-flight-cta']")).Click();
            
            // switch to first tab
            ((IJavaScriptExecutor)_webDriver).ExecuteScript("window.open()");
            List<string> tabs = new List<string>(_webDriver.WindowHandles);
            _webDriver.SwitchTo().Window(tabs[0]);

            // checkIn tab click
            _webDriver.FindElement(By.XPath("//div[@data-testid='check-in-horizontal-nav-tabs']")).Click();

            //add if condition
            Actions act = new Actions(_webDriver);
            act.SendKeys(Keys.Escape).Perform();

            // send keys (ticket number) CSS // add ticket generator//validation numbers//
            _webDriver.FindElement(By.CssSelector(".css-1cwyjr8.r-homxoj.r-ubezar.r-1eimq0t.r-1e081e0.r-xfkzu9.r-lnhwgy")).SendKeys("KVKDIW111"); ;
            Thread.Sleep(400); // get rid of thread.sleep

            // send keys (ticket email) CSS //
            _webDriver.FindElement(By.XPath("//input[@placeholder='john.doe@spicejet.com']")).SendKeys("john.doe@spicejet.com");

            // manage booking nav tab click
            _webDriver.FindElement(By.XPath("//div[@data-testid='manage booking-horizontal-nav-tabs']")).Click();

            // flights horizontal tab click
            _webDriver.FindElement(By.XPath("//div[@data-testid='Flights-horizontal-nav-tabs']")).Click();

            //round trip radio button click
            _webDriver.FindElement(By.XPath("//div[@data-testid='round-trip-radio-button']")).Click();

            //one way radio button click
            _webDriver.FindElement(By.XPath("//div[@data-testid='one-way-radio-button']")).Click();

            //from field click
            _webDriver.FindElement(By.XPath("//div[@data-testid='to-testID-origin']")).Click();

            //flying from Mumbai airport selection
            _webDriver.FindElement(By.XPath("//div[text()='Chhatrapati Shivaji International Airport']")).Click();
            Thread.Sleep(800);

            //flying to Delhi airport selection
            _webDriver.FindElement(By.XPath("//div[text()='Indira Gandhi International Airport']")).Click();

            //change from and to destination arrow click
            _webDriver.FindElement(By.XPath("//div[@data-testid='to-testID-flip-arrow']")).Click();

            //to field destination click
            _webDriver.FindElement(By.XPath("//div[@data-testid='to-testID-destination']")).Click();

            //international destination selection click
            _webDriver.FindElement(By.XPath("//div[text()='International']")).Click();
            Thread.Sleep(400);

            //select Kutaisi airport
            _webDriver.FindElement(By.XPath("//div[text()='Kutaisi Airport']")).Click();
            Thread.Sleep(2000);

            //select 3 of august date USING CSS
            _webDriver.FindElement(By.CssSelector("div[data-testid='undefined-month-August-2022'] [data-testid='undefined-calendar-day-3']")).Click();
            Thread.Sleep(400);

            //click return date date picker CSS
            _webDriver.FindElement(By.CssSelector("div[data-testid='return-date-dropdown-label-test-id']")).Click();
            Thread.Sleep(400);

            _webDriver.FindElement(By.CssSelector("div[data-testid='undefined-month-September-2022'] [data-testid='undefined-calendar-day-22']")).Click();
            Thread.Sleep(400);

            _webDriver.FindElement(By.CssSelector("div[data-testid='home-page-travellers']")).Click();
 
            //double click number of children CSS
            var numberOfChildren = _webDriver.FindElement(_numberOfChildren);
            act.DoubleClick(numberOfChildren).Perform();

            //one click to add one more adult passenger CSS
            _webDriver.FindElement(By.CssSelector("div[data-testid='Adult-testID-plus-one-cta']")).Click();

            // currency drop-down click
            _webDriver.FindElement(By.XPath("//div[text()='Currency']")).Click();

            // currency USD Xpath selector click
            _webDriver.FindElement(By.XPath("//div[text()='USD']")).Click();
            Thread.Sleep(400);

            //students Radio button css selector click
            _webDriver.FindElement(By.XPath("//div[text()='Students']")).Click();
            Thread.Sleep(600);

            //search Flight button xpath button click
            _webDriver.FindElement(By.XPath("//div[@data-testid='home-page-flight-cta']")).Click();

            _webDriver.Quit();
        }
    }
}