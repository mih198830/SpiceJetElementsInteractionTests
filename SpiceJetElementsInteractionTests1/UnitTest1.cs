using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System.Collections;

namespace SpiceJetElementsInteractionTests1
{
    public class Tests
    {
        private IWebDriver driver;
        private readonly By _covidLink = By.XPath("//div[text()='COVID-19 Information']");
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
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Navigate().GoToUrl("https://www.spicejet.com/");
            driver.Manage().Window.Maximize();
            
        }

        [Test]
        public void RoundTripRadioButtonClick()
        {

            var covidLink = driver.FindElement(_covidLink);
            covidLink.Click(); // open COVID-19 rules link in new tab

            ((IJavaScriptExecutor)driver).ExecuteScript("window.open()");
            List<string> tabs = new List<string>(driver.WindowHandles);
            driver.SwitchTo().Window(tabs[0]); // switch to first tab

            ChromeOptions op = new ChromeOptions();
            op.AddArguments("--disable-notifications");

            var checkInTab = driver.FindElement(_checkInTab);
            checkInTab.Click(); // checkIn tab click

            Actions act = new Actions(driver);
            act.SendKeys(OpenQA.Selenium.Keys.Escape).Perform();

            var ticketNumber = driver.FindElement(_ticketNumber);
            ticketNumber.SendKeys("KVKDIW111"); // send keys (ticket number) CSS
            Thread.Sleep(400);
       
            var ticketEmail = driver.FindElement(_ticketEmail);
            ticketEmail.SendKeys("john.doe@spicejet.com"); // send keys (ticket email) CSS

            var manageBookingHorizontalNavTab = driver.FindElement(_manageBookingHorizontalNavTab);
            manageBookingHorizontalNavTab.Click(); // manage booking nav tab click

            var flightsHorizontalTab = driver.FindElement(_flightsHorizontalTab);
            flightsHorizontalTab.Click(); // flights horizontal tab click

            var roundTrip = driver.FindElement(_roundTripRadioButton);
            roundTrip.Click(); //round trip radio button click

            var oneWay = driver.FindElement(_oneWayTripRadioButton);
            oneWay.Click(); //one way radio button click

            var fromField = driver.FindElement(_fromField);
            fromField.Click(); //from field click

            var fromMumbaiAirport = driver.FindElement(_fromMumbaiAirport);
            fromMumbaiAirport.Click(); //flying from Mumbai airport selection
            Thread.Sleep(700);

            var delhiAerport = driver.FindElement(_delhiAerport);
            delhiAerport.Click(); //flying to Delhi airport selection
            Thread.Sleep(600);

            var flipFromToPlaces = driver.FindElement(_flipFromToPlaces);
            flipFromToPlaces.Click(); //change from and to destination arrow click
            Thread.Sleep(400);

            var toField = driver.FindElement(_toField);
            toField.Click(); //to field destination click
            var internationalDestination = driver.FindElement(_internationalDestiantion);
            internationalDestination.Click();//international destination selection click
            Thread.Sleep(400);

            var kutaisiAirport = driver.FindElement(_kutaisiAerport);
            kutaisiAirport.Click();//select Kutaisi airport
            Thread.Sleep(2000);

            var augustDate = driver.FindElement(_augustDate);
            augustDate.Click(); //select 3 of august date USING CSS
            Thread.Sleep(400);

            var returnDate = driver.FindElement(_returnDate);
            returnDate.Click();//click return date date picker CSS
            Thread.Sleep(400);

            var septemberDate = driver.FindElement(_septemberDate);
            septemberDate.Click();
            Thread.Sleep(400);

            var numberOfTravellers = driver.FindElement(_numberOfTravellers);
            numberOfTravellers.Click();

            var numberOfChildren = driver.FindElement(_numberOfChildren);
            act.DoubleClick(numberOfChildren).Perform();//double click number of children CSS
            
            var numberOfAdults = driver.FindElement(_numberOfAdults);
            numberOfAdults.Click();//one click to add one more adult passenger CSS

            var currency = driver.FindElement(_currency);
            currency.Click(); // currency drop-down click

            var currencyUSD = driver.FindElement(_currencyUSD);
            currencyUSD.Click();// currency USD Xpath selector click
            Thread.Sleep(400);

            var studentsRadioBox = driver.FindElement(_studentsRadioBox);
            studentsRadioBox.Click();//students Radio button css selector click
            Thread.Sleep(600);

           
            var searchFlightButtonClick = driver.FindElement(_searchFlightButtonClick);
            searchFlightButtonClick.Click();//search Flight button xpath button click

            driver.Quit();
        }

    }
}