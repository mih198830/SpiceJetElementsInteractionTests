using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using SpiceJetElementsInteractionTests1.PageObject;
using System.ComponentModel;

namespace SpiceJetElementsInteractionTests1
{
    [TestFixture(Author = "Mikhail Matskevich", Description = "Flight service SpiceJet.com tests")]
    [AllureNUnit(false)]
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
        [AllureTag("SpiceJet", "Flights Tab")]
        [AllureSeverity(SeverityLevel.critical)]
        
        [DisplayName("Ñheck all elements on Flights Tab are interactable")]
        public void FlightsPageElementsCheck()
        {
            var checkInTab = new CheckInPageObject(_webDriver);
            var flightsTab = new FlightsTabPageObject(_webDriver);


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
            flightsTab.FromBomSelection()
            , "Select Airport Mumbai as a flying from place");

            AllureLifecycle.Instance.WrapInStep(() =>
            flightsTab.FlipArrowClick()
            , "Click Flip Arrow icon and make Mumbai as Flying To place");


            AllureLifecycle.Instance.WrapInStep(() =>
            flightsTab.ToFieldClick()
            , "Click Flying To field");

            AllureLifecycle.Instance.WrapInStep(() =>
            flightsTab.DepartureDateClick()
            , "Click to Departure date field to trigger date-picker");

            AllureLifecycle.Instance.WrapInStep(() =>
            flightsTab.FromDateSelect()
            , "Select From Date");

            AllureLifecycle.Instance.WrapInStep(() =>
            flightsTab.ToDateSelect()
            , "Select To Date");

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
    }
}
