using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using SpiceJetElementsInteractionTests1.PageObject;
using System.ComponentModel;

//Scenarios on the flight app https://www.spicejet.com/
//Could you automate dates - Valid, in valid, same date with different time
//From : Delhi, To: Chennai - Select a flight that starts post 12pm with cheapest fare from today until the next 3 days.

namespace SpiceJetElementsInteractionTests1
{
    [TestFixture(Author = "Mikhail Matskevich", Description = "Flight service SpiceJet.com tests")]
    [AllureNUnit(true)]
    [AllureLink("https://github.com/mih198830/SpiceJetElementsInteractionTests")]
    [AllureLink("https://www.spicejet.com/")]
    [AllureFeature("Core")]
    public class Tests : BaseClass
    {

        [Test]
        [AllureTag("SpiceJet", "Title")]
        [AllureSeverity(SeverityLevel.normal)]
        [DisplayName("Check if page title is equal to expected text")]
        public void CheckPageTitleValue()
        {
            String expectedTitle = "SpiceJet - Flight Booking for Domestic and International, Cheap Air Tickets";
            String title = _webDriver.Title;
            AllureLifecycle.Instance.WrapInStep(() =>
                Assert.That(title.Contains(expectedTitle), Is.EqualTo(true), "Title is not matching")
            , "Check that page title is matching expected text");

        }

        [Test]
        public void CheckImageAndText()
        {
            var flightsTab = new FlightsTabPageObject(_webDriver);
            String expectedTextFromImage = "on hotel";
            flightsTab.MakeMainPageScreenshot();
            flightsTab.GetTextFromScreenshot();
            Assert.That(flightsTab.GetTextFromScreenshot, Does.Contain(expectedTextFromImage));
        }

        [Test]
        public void CheckEmptyDestinationField()
        {
            String expectedTitle = "SpiceJet - Flight Booking for Domestic and International, Cheap Air Tickets";
            String title = _webDriver.Title;
            var flightsTab = new FlightsTabPageObject(_webDriver);
            flightsTab.SearchFlightClick();
            flightsTab.DestinationCityPopUpDisplayed();

        }

        [Test]
        public void CheapestFareFromTodayUntilNextThreeDays()
        {
            var flightsTab = new FlightsTabPageObject(_webDriver);
            var flightSearchTab = new FlightSearchPageObject(_webDriver);
            flightsTab.FlightsTabClick();
            flightsTab.FromFieldClick();
            flightsTab.DelhiAirportClick();
            flightsTab.ChennaiAirportClick();
            flightsTab.FromDatePlusOneDay();
            flightsTab.SearchFlightClick();
            var firstPrice = flightSearchTab.threeDaysLowestPriceSelect(0, 1);
            string secondPrice = flightSearchTab.threeDaysLowestPriceSelect(0, 2);
            string thirdPrice = flightSearchTab.threeDaysLowestPriceSelect(0, 3);
            var getLowestPriceWithDate = flightSearchTab.smallestPriceFromThreeDays(firstPrice, secondPrice, thirdPrice);
            flightSearchTab.SelectLowFlight(getLowestPriceWithDate);
        }



        [Test]
        public void FlightsPageElementsCheck()
        {
            var checkInTab = new CheckInPageObject(_webDriver);
            var flightsTab = new FlightsTabPageObject(_webDriver);
            var flightSearchTab = new FlightSearchPageObject(_webDriver);
            var signUpLink = new SightUpPageObject(_webDriver);
            flightsTab.FlightsTabClick();
            flightsTab.OneWayButtonClickAssert();
            flightsTab.RoundTripRadioButtonClick();
            flightsTab.FromFieldClick();
            flightsTab.randomAirportFromArr();
            flightsTab.randomAirportToArr();
            flightsTab.FromDateSelect();
            flightsTab.ToDateSelect();
            flightsTab.NumberOfTravellersDropDownClick();
            flightsTab.NumberOfAdultsAddOne();
            flightsTab.NumberOfAdultsUptToSevenClick();
            flightsTab.CurrencyClick();
            flightsTab.UsdCurrencyClickAndAssert();
            flightsTab.SearchFlightClick();
            flightSearchTab.SignUpButtonClick();

            var browserTabs = _webDriver.WindowHandles;
            _webDriver.SwitchTo().Window(browserTabs[1]);
            signUpLink.FlightsLiClick();
            signUpLink.PartnersLinkClick();
            signUpLink.CreditCardsLinkClick();
        }

        [Test]
        public void ManageBookingTabCheck()
        {
            var manageBookingTab = new ManageBookingPageObject(_webDriver);
            manageBookingTab.ManageBookingLinkClick();
            manageBookingTab.ViewChangeAssistButtonAssertIsNotNull();
        }


        [Test]
        [AllureTag("SpiceJet", "Search flight")]
        [AllureSeverity(SeverityLevel.critical)]
        [DisplayName("Check search flight process for newly loaded page")]
        public void SearchDefaultValues()
        {
            var flightsTab = new FlightsTabPageObject(_webDriver);

            AllureLifecycle.Instance.WrapInStep(() =>
                flightsTab.SearchButtonClick()
            , "Click Search button from Flights Tab Page");

            AllureLifecycle.Instance.WrapInStep(() =>
                flightsTab.DismisButtonPresent()
            , "Check that Error message with expected text is present as an error");
        }

        [Test]
        [AllureTag("SpiceJet", "Link Click")]
        [AllureSeverity(SeverityLevel.critical)]
        [DisplayName("Corporate page elements checks")]
        public void ClickLink()
        {
            var flightsTab = new FlightsTabPageObject(_webDriver);

            AllureLifecycle.Instance.WrapInStep(() =>
                flightsTab.CovidLinkClick()
            , "Click Covid-19 link from main page");
        }


        [Test]
        [AllureTag("SpiceJet", "Check In Tab")]
        [AllureSeverity(SeverityLevel.normal)]
        [DisplayName("Check In Tab field fill in with random data")]

        public void CheckInTabFieldsCheck()
        {

            var flightsTab = new FlightsTabPageObject(_webDriver);
            var checkInTab = new CheckInPageObject(_webDriver);

            AllureLifecycle.Instance.WrapInStep(() =>
            flightsTab.CheckInTabClick()
            , "Click Check In Tab field");

            AllureLifecycle.Instance.WrapInStep(() =>
            checkInTab.SendRandomEmail()
            , "Fill in Email field with random email data");

            AllureLifecycle.Instance.WrapInStep(() =>
            checkInTab.ClearEmailField()
            , "Clear email printed email in field");
        }

        [Test]
        [AllureTag("SpiceJet", "Login")]
        [AllureSeverity(SeverityLevel.critical)]
        [DisplayName("Login with random email and assert error text is present")]

        public void LoginWithEmptyData()
        {
            var loginTab = new LoginPageObject(_webDriver);

            AllureLifecycle.Instance.WrapInStep(() =>
            loginTab.LoginButtonFromMainPageClick()
            , "Click Login button from main page");

            AllureLifecycle.Instance.WrapInStep(() =>
            loginTab.LoginMenuRandomPhoneNumber()
            , "Send Random Phone Number and Assert that error text is present");
        }

        [Test]
        [AllureTag("SpiceJet", "Registration")]
        [AllureSeverity(SeverityLevel.critical)]
        [DisplayName("Registration page opens in a new window")]

        public void RegistrationPageOpens()
        {
            var signUp = new FlightsTabPageObject(_webDriver);

            AllureLifecycle.Instance.WrapInStep(() =>
            signUp.SignUpClick()
            , "Click SignUp button from main page");


            var browserTabs = _webDriver.WindowHandles;
            _webDriver.SwitchTo().Window(browserTabs[1]);
            Thread.Sleep(2000);
            String CurrentUrl = _webDriver.Url;
            Assert.That(CurrentUrl, Is.EqualTo("https://spiceclub.spicejet.com/signup"));
        }
    }
}
