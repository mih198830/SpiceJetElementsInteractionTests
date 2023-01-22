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


    }
}
