using Akka.Util;
using Bogus;
using Bogus.DataSets;
using Microsoft.VisualBasic;
using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using System;
using System.Globalization;
using WebDriverManager;

namespace SpiceJetElementsInteractionTests1.PageObject
{
    class FlightsTabPageObject
    {
        private IWebDriver _webdriver;

        private readonly By _covidInformationLink = By.XPath("//div[text()='COVID-19 Information']");
        private readonly By _checkInTab = By.XPath("//div[@data-testid='check-in-horizontal-nav-tabs']");
        private readonly By _roundTripRadioButton = By.XPath("//div[@data-testid='round-trip-radio-button']");
        private readonly By _fromField = By.XPath("//*[@data-testid='to-testID-origin']");
        private readonly By _flightsTab = By.XPath("//div[@data-testid='Flights-horizontal-nav-tabs']");
        private readonly By _oneWayTripRadioButton = By.XPath("//div[@data-testid='one-way-radio-button']");
        private readonly By _flipFromToPlaces = By.XPath("//div[@data-testid='to-testID-flip-arrow']");
        private readonly By _toField = By.XPath("//div[@data-testid='to-testID-destination']");
        private readonly By _returnDate = By.CssSelector("div[data-testid='return-date-dropdown-label-test-id']");
        private readonly By _departureDate = By.XPath("//div[@data-testid='departure-date-dropdown-label-test-id']");
        private readonly By _internationalDestiantion = By.XPath("//div[text()='International']");
        private readonly By _numberOfTravellers = By.CssSelector("div[data-testid='home-page-travellers']");
        private readonly By _numberOfChildren = By.CssSelector("div[data-testid='Children-testID-plus-one-cta']");
        private readonly By _numberOfAdults = By.CssSelector("div[data-testid='Adult-testID-plus-one-cta']");
        private readonly By _currency = By.XPath("//div[text()='Currency']");
        private readonly By _usd = By.XPath("//div[text()='USD']");
        private readonly By _seniorCitizen = By.XPath("//div[text()='Senior Citizen']");
        private readonly By _searchButton = By.XPath("//div[@data-testid='home-page-flight-cta']");
        private readonly By _errorMessage = By.XPath("//div[text()='DISMISS']");
        private readonly By _signUp = By.XPath("//div[text()='Signup']");
        private readonly By _btnSearchFlightCta = By.XPath("//div[@data-testid='home-page-flight-cta']");
        private readonly By _calendarRow = By.CssSelector(".css-1dbjc4n.r-6koalj.r-18u37iz.r-d0pm55");


        public FlightsTabPageObject(IWebDriver webdriver)
        {
            _webdriver = webdriver;
        }

        public FlightsTabPageObject randomAirportFromArr()
        {
            String[] airportsNames = { "AGR", "AMD", "KQH", "ATQ", "IXB", "IXG", "BLR", "BHU", "BHO", "IXC", "MAA", "CJB", "DBR" };
            Random rnd = new Random();
            int randAirportIdx = rnd.Next(airportsNames.Length);
            String randomAirportFromElem = airportsNames[randAirportIdx];
            _webdriver.FindElement(By.XPath($"//div[text()='{randomAirportFromElem}']")).Click();
            return new FlightsTabPageObject(_webdriver);
        }

        public FlightsTabPageObject randomAirportToArr()
        {
            String[] airportsNames = { "DED", "DEL", "DHM", "RDP", "GOI", "GOP", "GAU", "GWL", "HYD", "JLR", "JAI", "JSA", "AIP" };
            Random rnd = new Random();
            int randAirportIdx = rnd.Next(airportsNames.Length);
            String randomAirportToElem = airportsNames[randAirportIdx];
            _webdriver.FindElement(By.XPath($"//div[text()='{randomAirportToElem}']")).Click();
            return new FlightsTabPageObject(_webdriver);
        }

        public CheckInPageObject CheckInTabClick()
        {
            _webdriver.FindElement(_checkInTab).Click();
            return new CheckInPageObject(_webdriver);
        }

        public CheckInPageObject CalendarRowClick()
        {
            _webdriver.FindElement(_calendarRow);
            return new CheckInPageObject(_webdriver);
        }

        public FlightsTabPageObject RoundTripRadioButtonClick()
        {
            _webdriver.FindElement(_roundTripRadioButton).Click();
            return new FlightsTabPageObject(_webdriver);
        }

        public FlightsTabPageObject CovidLinkClick()
        {
            _webdriver.FindElement(_covidInformationLink).Click();
            return new FlightsTabPageObject(_webdriver);
        }


        public FlightsTabPageObject FromFieldClick()
        {
            _webdriver.FindElement(_fromField).Click();
            return new FlightsTabPageObject(_webdriver);
        }

        public FlightsTabPageObject FromFieldSendRandomNumbers()
        {
            string randomNumbers = Faker.Phone.Number();

            _webdriver.FindElement(_fromField).SendKeys(Keys.Enter);
            return new FlightsTabPageObject(_webdriver);
        }

        public FlightsTabPageObject FlightsTabClick()
        {
            _webdriver.FindElement(_flightsTab).Click();
            return new FlightsTabPageObject(_webdriver);
        }

        public FlightsTabPageObject OneWayButtonClickAssert()
        {
            var oneWayRadioButton = _webdriver.FindElement(_oneWayTripRadioButton);
            oneWayRadioButton.Click();
            Assert.That(oneWayRadioButton.Selected, Is.EqualTo(false));
            _webdriver.FindElement(_oneWayTripRadioButton).Click();
            return new FlightsTabPageObject(_webdriver);
        }

        public FlightsTabPageObject FlipArrowClick()
        {
            _webdriver.FindElement(_flipFromToPlaces).Click();
            return new FlightsTabPageObject(_webdriver);
        }
        public FlightsTabPageObject ToFieldClick()
        {
            _webdriver.FindElement(_toField).Click();
            return new FlightsTabPageObject(_webdriver);
        }

        public FlightsTabPageObject ReturnDateFieldClick()
        {
            _webdriver.FindElement(_returnDate).Click();
            return new FlightsTabPageObject(_webdriver);
        }

        public FlightsTabPageObject DepartureDateClick()
        {
            _webdriver.FindElement(_departureDate).Click();
            return new FlightsTabPageObject(_webdriver);
        }

        public FlightsTabPageObject InternationalDestinationClick()
        {
            _webdriver.FindElement(_internationalDestiantion).Click();
            return new FlightsTabPageObject(_webdriver);
        }

        public FlightsTabPageObject FromDateSelect()
        {
            //Random r = new Random();
            //int rInt = r.Next(1, 15);
            //String number = rInt.ToString();

            DateTime dateForMonthSelection = DateTime.Now.AddDays(3);
            DateTime dateForDateSelectionFrom = DateTime.Now.AddDays(1);
            string monthName = dateForMonthSelection.ToString("MMMM");
            string dateFrom = dateForDateSelectionFrom.ToString("%d");
            Console.WriteLine(monthName);
            Console.WriteLine(dateFrom);
            _webdriver.FindElement(By.XPath($"//div[@data-testid='undefined-month-{monthName}-2022']//div[@data-testid='undefined-calendar-day-{dateFrom}']")).Click();
            return new FlightsTabPageObject(_webdriver);
        }

        public FlightsTabPageObject ToDateSelect()
        {
            //Random r = new Random();
            //int rInt = r.Next(17, 28);
            //String number = rInt.ToString();

            DateTime dateForMonthSelectionTo = DateTime.Now.AddDays(35);
            DateTime dateForDateSelectionFrom = DateTime.Now.AddDays(7);
            string monthNameTo = dateForMonthSelectionTo.ToString("MMMM");
            string dateTo = dateForDateSelectionFrom.ToString("%d");
            Console.WriteLine(monthNameTo);
            Console.WriteLine(dateTo);
            _webdriver.FindElement(By.XPath($"//div[@data-testid='undefined-month-{monthNameTo}-2022']//div[@data-testid='undefined-calendar-day-{dateTo}']")).Click();
            return new FlightsTabPageObject(_webdriver);
        }

        public FlightsTabPageObject NumberOfTravellersDropDownClick()
        {
            _webdriver.FindElement(_numberOfTravellers).Click();
            return new FlightsTabPageObject(_webdriver);
        }

      

        public FlightsTabPageObject NumberOfAdultsAddOne()
        {
            _webdriver.FindElement(_numberOfAdults).Click();
            return new FlightsTabPageObject(_webdriver);
        }

        public FlightsTabPageObject NumberOfAdultsUptToSevenClick()
        {
            //Five clicks to add 6 more adult passengers CSS
            for (int i = 1; i < 6; i++)
            {
                _webdriver.FindElement(_numberOfAdults).Click();
            }
            return new FlightsTabPageObject(_webdriver);
        }

        public FlightsTabPageObject CurrencyClick()
        {
            _webdriver.FindElement(_currency).Click();
            return new FlightsTabPageObject(_webdriver);
        }

        public FlightsTabPageObject UsdCurrencyClickAndAssert()
        {
            _webdriver.FindElement(_usd).Click();
            String CurrencyUSD = _webdriver.FindElement(_usd).Text;
            Assert.AreEqual("USD", CurrencyUSD);
            return new FlightsTabPageObject(_webdriver);
        }

        public FlightsTabPageObject SeniorCitizenClickAndAssert()
        {
            _webdriver.FindElement(_seniorCitizen).Click();

            String ChoosedRadioButton = _webdriver.FindElement(_seniorCitizen).Text;
            Assert.That("Senior Citizen", Is.EqualTo(ChoosedRadioButton));
            return new FlightsTabPageObject(_webdriver);
        }

        public FlightsTabPageObject SearchButtonClick()
        {
            _webdriver.FindElement(_searchButton).Click();
            return new FlightsTabPageObject(_webdriver);
        }

        public FlightsTabPageObject DismisButtonPresent()
        {
            String errorText = _webdriver.FindElement(_errorMessage).Text;
            Assert.AreEqual("DISMISS", errorText);
            return new FlightsTabPageObject(_webdriver);
        }

        public FlightsTabPageObject SignUpClick()
        {
            _webdriver.FindElement(_signUp).Click();
            return new FlightsTabPageObject(_webdriver);
        }

        public FlightsTabPageObject SearchFlightClick()
        {
            _webdriver.FindElement(_btnSearchFlightCta).Click();
            return new FlightsTabPageObject(_webdriver);
        }
    }
}

