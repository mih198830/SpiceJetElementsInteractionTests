using Akka.Actor.Dsl;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiceJetElementsInteractionTests1.PageObject
{
    class FlightsTabPageObject
    {
        private IWebDriver _webdriver;

        private readonly By _covidInformationLink = By.XPath("//div[text()='COVID-19 Information']");
        private readonly By _checkInTab = By.XPath("//div[@data-testid='check-in-horizontal-nav-tabs']");
        private readonly By _roundTripRadioButton = By.XPath("//div[@data-testid='round-trip-radio-button']");
        private readonly By _fromField = By.XPath("//*[@data-testid='to-testID-origin']");
        private readonly By _fromBom = By.XPath("//div[text()='BOM']");
        private readonly By _toAgr = By.XPath("//div[text()='AGR']");
        private readonly By _flightsTab = By.XPath("//div[@data-testid='Flights-horizontal-nav-tabs']");
        private readonly By _oneWayTripRadioButton = By.XPath("//div[@data-testid='one-way-radio-button']");
        private readonly By _flipFromToPlaces = By.XPath("//div[@data-testid='to-testID-flip-arrow']");
        private readonly By _toField = By.XPath("//div[@data-testid='to-testID-destination']");
        private readonly By _returnDate = By.CssSelector("div[data-testid='return-date-dropdown-label-test-id']");
        private readonly By _departureDate = By.XPath("//div[@data-testid='departure-date-dropdown-label-test-id']");
        private readonly By _internationalDestiantion = By.XPath("//div[text()='International']");
        private readonly By _octoberDate = By.CssSelector("div[data-testid='undefined-month-October-2022'] [data-testid='undefined-calendar-day-25']");
        private readonly By _octoberDateTo = By.CssSelector("div[data-testid='undefined-month-October-2022'] [data-testid='undefined-calendar-day-29']");
        private readonly By _numberOfTravellers = By.CssSelector("div[data-testid='home-page-travellers']");
        private readonly By _numberOfChildren = By.CssSelector("div[data-testid='Children-testID-plus-one-cta']");
        private readonly By _numberOfAdults = By.CssSelector("div[data-testid='Adult-testID-plus-one-cta']");
        private readonly By _currency = By.XPath("//div[text()='Currency']");
        private readonly By _usd = By.XPath("//div[text()='USD']");
        private readonly By _seniorCitizen = By.XPath("//div[text()='Senior Citizen']");
        private readonly By _searchButton = By.XPath("//div[@data-testid='home-page-flight-cta']");
        private readonly By _errorMessage = By.XPath("//div[text()='DISMISS']");

        public FlightsTabPageObject(IWebDriver webdriver)
        {
            _webdriver = webdriver;
        }

        public CheckInPageObject CheckInTabClick()
        {
            _webdriver.FindElement(_checkInTab).Click();
            return new CheckInPageObject(_webdriver);
        }

        public FlightsTabPageObject RoundTripRadioButtonClick()
        {
            _webdriver.FindElement(_roundTripRadioButton).Click();
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

        public FlightsTabPageObject FromBomSelection()
        {
            _webdriver.FindElement(_fromBom).Click();
            return new FlightsTabPageObject(_webdriver);
        }

        public FlightsTabPageObject ToAgrSelection()
        {
            _webdriver.FindElement(_toAgr).Click();
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
            _webdriver.FindElement(_octoberDate).Click();
            return new FlightsTabPageObject(_webdriver);
        }

        public FlightsTabPageObject ToDateSelect()
        {
            _webdriver.FindElement(_octoberDateTo).Click();
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
    }
}
