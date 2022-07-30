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

        public readonly By _covidLink = By.XPath("//div[text()='COVID-19 Information']");
        private readonly By _roundTripRadioButton = By.XPath("//div[@data-testid='round-trip-radio-button']");
        private readonly By _oneWayTripRadioButton = By.XPath("//div[@data-testid='one-way-radio-button']");
        private readonly By _checkInTab = By.XPath("//div[@data-testid='check-in-horizontal-nav-tabs']");
        private readonly By _ticketNumber = By.CssSelector(".css-1cwyjr8.r-homxoj.r-ubezar.r-1eimq0t.r-1e081e0.r-xfkzu9.r-lnhwgy");
        private readonly By _ticketEmail = By.XPath("//input[@placeholder='john.doe@spicejet.com']");
        private readonly By _flightsHorizontalTab = By.XPath("//div[@data-testid='Flights-horizontal-nav-tabs']");
        private readonly By _manageBookingHorizontalNavTab = By.XPath("//div[@data-testid='manage booking-horizontal-nav-tabs']");
        private readonly By _fromField = By.XPath("//div[@data-testid='to-testID-origin']");
        private readonly By _toField = By.XPath("//div[@data-testid='to-testID-destination']");
        private readonly By _fromMumbaiAirport = By.XPath("//div[text()='Chhatrapati Shivaji International Airport']");
        private readonly By _delhiAerport = By.XPath("//div[text()='Indira Gandhi International Airport']");
        private readonly By _kutaisiAerport = By.XPath("//div[text()='Kutaisi Airport']");
        private readonly By _flipFromToPlaces = By.XPath("//div[@data-testid='to-testID-flip-arrow']");
        private readonly By _internationalDestiantion = By.XPath("//div[text()='International']");
        private readonly By _departureDate = By.XPath("//div[@data-testid='departure-date-dropdown-label-test-id']");
        private readonly By _rightArrowCalendarPicker = By.XPath("//div[@class='css-1dbjc4n r-1loqt21 r-u8s1d r-11xbo3g r-1v2oles r-1otgn73 r-16zfatd r-eafdt9 r-1i6wzkk r-lrvibr r-184en5c']");
        private readonly By _augustDate = By.CssSelector("div[data-testid='undefined-month-August-2022'] [data-testid='undefined-calendar-day-3']");
        private readonly By _returnDate = By.CssSelector("div[data-testid='return-date-dropdown-label-test-id']");
        private readonly By _septemberDate = By.CssSelector("div[data-testid='undefined-month-September-2022'] [data-testid='undefined-calendar-day-22']");
        private readonly By _numberOfTravellers = By.CssSelector("div[data-testid='home-page-travellers']");
        private readonly By _numberOfChildren = By.CssSelector("div[data-testid='Children-testID-plus-one-cta']");
        private readonly By _numberOfAdults = By.CssSelector("div[data-testid='Adult-testID-plus-one-cta']");
        private readonly By _currency = By.XPath("//div[text()='Currency']");
        private readonly By _currencyUSD = By.XPath("//div[text()='USD']");
        private readonly By _studentsRadioBox = By.XPath("//div[text()='Students']");
        private readonly By _searchFlightButtonClick = By.XPath("//div[@data-testid='home-page-flight-cta']");

        [SetUp]
        public void Setup()
        {
            //new DriverManager().SetUpDriver(new ChromeConfig());
            //_webDriver = new ChromeDriver();
            new DriverManager().SetUpDriver(new FirefoxConfig());
            _webDriver = new FirefoxDriver();
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

            //ChromeOptions op = new ChromeOptions();
            //op.AddArguments("--disable-notifications");

            // checkIn tab click
            var checkInTab = _webDriver.FindElement(_checkInTab);
            checkInTab.Click();

            //add if condition
            Actions act = new Actions(_webDriver);
            act.SendKeys(OpenQA.Selenium.Keys.Escape).Perform();

            // send keys (ticket number) CSS // add ticket generator//validation numbers//
            var ticketNumber = _webDriver.FindElement(_ticketNumber);
            ticketNumber.SendKeys("KVKDIW111"); 
            Thread.Sleep(400); // get rid of thread.sleep

            // send keys (ticket email) CSS //
            var ticketEmail = _webDriver.FindElement(_ticketEmail);
            ticketEmail.SendKeys("john.doe@spicejet.com");

            // manage booking nav tab click
            var manageBookingHorizontalNavTab = _webDriver.FindElement(_manageBookingHorizontalNavTab);
            manageBookingHorizontalNavTab.Click();

            // flights horizontal tab click
            var flightsHorizontalTab = _webDriver.FindElement(_flightsHorizontalTab);
            flightsHorizontalTab.Click();

            //round trip radio button click
            var roundTrip = _webDriver.FindElement(_roundTripRadioButton);
            roundTrip.Click();

            //one way radio button click
            var oneWay = _webDriver.FindElement(_oneWayTripRadioButton);
            oneWay.Click();

            //from field click
            var fromField = _webDriver.FindElement(_fromField);
            fromField.Click();

            //flying from Mumbai airport selection
            var fromMumbaiAirport = _webDriver.FindElement(_fromMumbaiAirport);
            fromMumbaiAirport.Click(); 
            Thread.Sleep(700);

            //flying to Delhi airport selection
            var delhiAerport = _webDriver.FindElement(_delhiAerport);
            delhiAerport.Click(); 
            Thread.Sleep(600);

            //change from and to destination arrow click
            var flipFromToPlaces = _webDriver.FindElement(_flipFromToPlaces);
            flipFromToPlaces.Click(); 
            Thread.Sleep(400);

            //to field destination click
            var toField = _webDriver.FindElement(_toField);
            toField.Click();

            //international destination selection click
            var internationalDestination = _webDriver.FindElement(_internationalDestiantion);
            internationalDestination.Click();
            Thread.Sleep(400);

            //select Kutaisi airport
            var kutaisiAirport = _webDriver.FindElement(_kutaisiAerport);
            kutaisiAirport.Click();
            Thread.Sleep(2000);

            //select 3 of august date USING CSS
            var augustDate = _webDriver.FindElement(_augustDate);
            augustDate.Click(); 
            Thread.Sleep(400);

            //click return date date picker CSS
            var returnDate = _webDriver.FindElement(_returnDate);
            returnDate.Click();
            Thread.Sleep(400);

            var septemberDate = _webDriver.FindElement(_septemberDate);
            septemberDate.Click();
            Thread.Sleep(400);

            var numberOfTravellers = _webDriver.FindElement(_numberOfTravellers);
            numberOfTravellers.Click();

            //double click number of children CSS
            var numberOfChildren = _webDriver.FindElement(_numberOfChildren);
            act.DoubleClick(numberOfChildren).Perform();

            //one click to add one more adult passenger CSS
            var numberOfAdults = _webDriver.FindElement(_numberOfAdults);
            numberOfAdults.Click();

            // currency drop-down click
            var currency = _webDriver.FindElement(_currency);
            currency.Click();

            // currency USD Xpath selector click
            var currencyUSD = _webDriver.FindElement(_currencyUSD);
            currencyUSD.Click();
            Thread.Sleep(400);

            //students Radio button css selector click
            var studentsRadioBox = _webDriver.FindElement(_studentsRadioBox);
            studentsRadioBox.Click();
            Thread.Sleep(600);

            //search Flight button xpath button click
            var searchFlightButtonClick = _webDriver.FindElement(_searchFlightButtonClick);
            searchFlightButtonClick.Click();

            _webDriver.Quit();
        }

    }
}