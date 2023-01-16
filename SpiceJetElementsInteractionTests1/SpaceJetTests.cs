using NUnit.Framework;
using NUnit.Framework.Internal;
using SpiceJetElementsInteractionTests1.PageObject;

//Scenarios on the flight app https://www.spicejet.com/
//Could you automate dates - Valid, in valid, same date with different time
//From : Delhi, To: Chennai - Select a flight that starts post 12pm with cheapest fare from today until the next 3 days.

namespace SpiceJetElementsInteractionTests1
{
    public class Tests : BaseClass
    {

        [Test]
        public void CheckPageTitleValue()
        {
            String expectedTitle = "SpiceJet - Flight Booking for Domestic and International, Cheap Air Tickets";
            String title = _webDriver.Title;
            Assert.That(title.Contains(expectedTitle), Is.EqualTo(true), "Title is not matching");
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
            flightSearchTab.getValueFromTimeOfFlight();
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
        public void SearchDefaultValues()
        {
            var flightsTab = new FlightsTabPageObject(_webDriver);
            flightsTab.SearchButtonClick();
            flightsTab.DismisButtonPresent();
        }

        [Test]
        public void ClickLink()
        {
            var flightsTab = new FlightsTabPageObject(_webDriver);
            flightsTab.CovidLinkClick();
        }


        [Test]
        public void CheckInTabFieldsCheck()
        {

            var flightsTab = new FlightsTabPageObject(_webDriver);
            var checkInTab = new CheckInPageObject(_webDriver);
            flightsTab.CheckInTabClick();
            checkInTab.SendRandomEmail();
            checkInTab.ClearEmailField();
        }

        [Test]
        public void LoginWithEmptyData()
        {
            var loginTab = new LoginPageObject(_webDriver);
            loginTab.LoginButtonFromMainPageClick();
            loginTab.LoginMenuRandomPhoneNumber();
        }

        [Test]
        public void RegistrationPageOpens()
        {
            var signUp = new FlightsTabPageObject(_webDriver);
            signUp.SignUpClick();
            var browserTabs = _webDriver.WindowHandles;
            _webDriver.SwitchTo().Window(browserTabs[1]);
            String CurrentUrl = _webDriver.Url;
            Assert.That(CurrentUrl, Is.EqualTo("https://spiceclub.spicejet.com/signup"));
        }
    }
}
