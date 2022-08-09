using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SpiceJetElementsInteractionTests1
{

    public class TestData
    {
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
        private readonly By _numberOfAdults = By.CssSelector("div[data-testid='Adult-testID-plus-one-cta']");
        private readonly By _currency = By.XPath("//div[text()='Currency']");
        private readonly By _currencyUSD = By.XPath("//div[text()='USD']");
        private readonly By _studentsRadioBox = By.XPath("//div[text()='Students']");
        private readonly By _searchFlightButtonClick = By.XPath("//div[@data-testid='home-page-flight-cta']");



        String randomFromAirport = RandomUtilsBase.randomSubjectFromArr();
    }
}
