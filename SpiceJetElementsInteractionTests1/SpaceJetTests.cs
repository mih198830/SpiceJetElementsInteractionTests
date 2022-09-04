using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using SpiceJetElementsInteractionTests1.PageObject;


namespace SpiceJetElementsInteractionTests1
{
    [TestFixture(Author = "Mikhail Matskevich", Description = "Flight service SpiceJet.com tests")]
    [AllureNUnit]
    [AllureLink("https://github.com/mih198830/SpiceJetElementsInteractionTests")]
    [AllureLink("https://www.spicejet.com/")]
    public class Tests : BaseClass
    {

        
        [AllureTag("SpiceJet", "Title")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureFeature("Core")]
        public void CheckPageTitleValue()
        {
            String expectedTitle = "SpiceJet - Flight Booking for Domestic and International, Cheap Air Tickets";
            String title = _webDriver.Title;
            AllureLifecycle.Instance.WrapInStep(() =>
            {
                Assert.That(title.Contains(expectedTitle), Is.EqualTo(true), "Title is not matching");
            }, "Check that page title is matching expected text");
        }


        [Test]
        [AllureTag("SpiceJet", "Manage Booking Tab")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureFeature("Core")]
        public void ManageBookingTabCheck()
        {
            var manageBookingTab = new ManageBookingPageObject(_webDriver);

            AllureLifecycle.Instance.WrapInStep(() =>
            {
                manageBookingTab.ManageBookingLinkClick();
            }, "Open Manage Bookin Tab");

            AllureLifecycle.Instance.WrapInStep(() =>
            {
                manageBookingTab.ViewChangeAssistButtonAssertIsNotNull();
            }, "Assert that button 'View Change Assist is visible");
        }

        
        public void FlightsPageElementsCheck()
        {
            var checkInTab = new CheckInPageObject(_webDriver);
            var flightsTab = new FlightsTabPageObject(_webDriver);
 
            // switch to first tab
            //((IJavaScriptExecutor)_webDriver).ExecuteScript("window.open()");
            //List<string> tabs = new List<string>(_webDriver.WindowHandles);
            //_webDriver.SwitchTo().Window(tabs[0]);

            

            flightsTab
                .FlightsTabClick()
                .OneWayButtonClickAssert()
                .RoundTripRadioButtonClick()
                .FromFieldClick()
                .FromBomSelection()
                .FlipArrowClick()
                .ToFieldClick()
                .DepartureDateClick()
                .FromDateSelect()
                .ToDateSelect()
                .NumberOfTravellersDropDownClick()
                .NumberOfAdultsAddOne()
                .NumberOfAdultsUptToSevenClick()
                .CurrencyClick()
                .UsdCurrencyClickAndAssert();
        }

        [Test]
        public void CheckInTabFieldsCheck()
        {
            var flightsTab = new FlightsTabPageObject(_webDriver);

            flightsTab
                .CheckInTabClick()
                .TicketNumberSendKeys()
                .SendRandomEmail()
                .ClearEmailField();
        }
    }
}