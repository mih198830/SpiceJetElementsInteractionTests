using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using SpiceJetElementsInteractionTests1.PageObject;


//August 2022 changelog
//- Used https://github.com/rosolko/WebDriverManager.Net so Firefox browser is working now (+ Chrome)
//  automatically downloads browser version and keeps updated
// - Replaced all Thread.Sleep with one line Implicit Wait timeout
// - Added FOR loop for 6 adults selection
// - Added Faker library usage for ticket number / Email generation
// - Updated Airports selectors to 3 letters (find by text)

// - OpenQA.Selenium - namespace with classes, interfaces, methods for different browsers (Chrome, Firefox, etc)
// https://www.selenium.dev/selenium/docs/api/java/org/openqa/selenium/package-summary.html
// - Added title test
// - radio-button assert added one-way trip
// - CTRL+K, CRTL+F - code formatting short-key


namespace SpiceJetElementsInteractionTests1
{
    [TestFixture(Author = "Mikhail Matskevich", Description = "Flight service tests")]
    [AllureNUnit]
    [AllureLink("https://github.com/unickq/allure-nunit")]
    public class Tests : BaseClass
    {

        [Test]
        [AllureStep("This method is just saying hello")]
        [AllureTag("NUnit", "Debug", "Title")]
        [AllureIssue("GitHub#1", "https://github.com/unickq/allure-nunit")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureFeature("Core")]
        public void CheckPageTitleValue()
        {
            String expectedTitle = "SpiceJet - Flight Booking for Domestic and International, Cheap Air Tickets";
            String title = _webDriver.Title;
            Assert.That(title.Contains(expectedTitle), Is.EqualTo(true), "Title is not matching");
        }

        [Test]
        public void FlightsPageElementsCheck()
        {
            var checkInTab = new CheckInPageObject(_webDriver);
            var flightsTab = new FlightsTabPageObject(_webDriver);
            var manageBookingTab = new ManageBookingPageObject(_webDriver);

 
            // switch to first tab
            ((IJavaScriptExecutor)_webDriver).ExecuteScript("window.open()");
            List<string> tabs = new List<string>(_webDriver.WindowHandles);
            _webDriver.SwitchTo().Window(tabs[0]);


            flightsTab
                .CheckInTabClick()
                .TicketNumberSendKeys()
                .SendRandomEmail()
                .ClearEmailField();

            manageBookingTab
                .ManageBookingLinkClick();

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
    }
}