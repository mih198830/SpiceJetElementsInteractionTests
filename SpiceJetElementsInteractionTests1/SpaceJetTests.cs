using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpiceJetElementsInteractionTests1.PageObject;
using System.ComponentModel;

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
        [AllureTag("SpiceJet", "Flights Tab")]
        [AllureSeverity(SeverityLevel.critical)]

        [DisplayName("Ñheck all elements on Flights Tab are interactable")]
        public void FlightsPageElementsCheck()
        {
            var checkInTab = new CheckInPageObject(_webDriver);
            var flightsTab = new FlightsTabPageObject(_webDriver);
            var flightSearchTab = new FlightSearchPageObject(_webDriver);
            var signUpLink = new SightUpPageObject(_webDriver);

            AllureLifecycle.Instance.WrapInStep(() =>
            flightsTab.FlightsTabClick()
            , "Click to Flights tab menu");

            AllureLifecycle.Instance.WrapInStep(() =>
            flightsTab.OneWayButtonClickAssert()
            , "Assert that One Way radio-button is clicked");

            AllureLifecycle.Instance.WrapInStep(() =>
            flightsTab.RoundTripRadioButtonClick()
            , "Click Round Trip radio-button");

            AllureLifecycle.Instance.WrapInStep(() =>
            flightsTab.FromFieldClick()
            , "Click Flying From field");

            AllureLifecycle.Instance.WrapInStep(() =>
            flightsTab.randomAirportFromArr()
            , "Select random airport as flying from place");


            AllureLifecycle.Instance.WrapInStep(() =>
            flightsTab.randomAirportToArr()
            , "Select random airport as flying to place");

            //Random r = new Random();
            //int rInt = r.Next(17, 28);
            //String number = rInt.ToString();
            //IList<IWebElement> dates = _webDriver.FindElements(By.XPath($"//div[@data-testid='undefined-calendar-day-{number}']"));
            //int count = dates.Count();
            //for (int i = 0; i < count; i++)
            //{
            //    String text = dates[0].Text;
            //    if (text.Equals("26"))
            //    {
            //        dates[i].Click();
            //        break;
            //    }
            //}

            AllureLifecycle.Instance.WrapInStep(() =>
            flightsTab.FromDateSelect()
            , "Select random date From");

            AllureLifecycle.Instance.WrapInStep(() =>
            flightsTab.ToDateSelect()
            , "Select random date To");

            AllureLifecycle.Instance.WrapInStep(() =>
            flightsTab.NumberOfTravellersDropDownClick()
            , "Number of Travellers drop-down menu click");

            AllureLifecycle.Instance.WrapInStep(() =>
            flightsTab.NumberOfAdultsAddOne()
            , "Number of Adults add one click");

            AllureLifecycle.Instance.WrapInStep(() =>
            flightsTab.NumberOfAdultsUptToSevenClick()
            , "Number of Adults add 6 more");

            AllureLifecycle.Instance.WrapInStep(() =>
            flightsTab.CurrencyClick()
            , "Currency drop-down menu click");

            AllureLifecycle.Instance.WrapInStep(() =>
            flightsTab.UsdCurrencyClickAndAssert()
            , "Assert that currency USD is checked");

            AllureLifecycle.Instance.WrapInStep(() =>
            flightsTab.SearchFlightClick()
            , "Click Search flight button");

            AllureLifecycle.Instance.WrapInStep(() =>
            flightSearchTab.SignUpButtonClick()
            , "Click Sign Up button");

            var browserTabs = _webDriver.WindowHandles;
            _webDriver.SwitchTo().Window(browserTabs[1]);
            signUpLink.FlightsLiClick();

            AllureLifecycle.Instance.WrapInStep(() =>
            signUpLink.PartnersLinkClick()
            , "Click Partners button");
            
        }

        [Test]
        [AllureTag("SpiceJet", "Manage Booking Tab")]
        [AllureSeverity(SeverityLevel.normal)]
        [DisplayName("Check if Manage Booking Tab is opened")]
        public void ManageBookingTabCheck()
        {
            var manageBookingTab = new ManageBookingPageObject(_webDriver);

            AllureLifecycle.Instance.WrapInStep(() =>
            manageBookingTab.ManageBookingLinkClick()
            , "Open Manage Bookin Tab");

            AllureLifecycle.Instance.WrapInStep(() =>
            manageBookingTab.ViewChangeAssistButtonAssertIsNotNull()
            , "Assert that button 'View Change Assist is visible");
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
            var corporatePage = new CorporatePageObject(_webDriver);

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
            Console.WriteLine(CurrentUrl);
            Assert.That(CurrentUrl, Is.EqualTo("https://spiceclub.spicejet.com/signup"));
        }
    }
}
