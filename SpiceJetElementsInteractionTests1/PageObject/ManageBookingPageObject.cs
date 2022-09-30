using NUnit.Framework;
using OpenQA.Selenium;

namespace SpiceJetElementsInteractionTests1.PageObject
{
    public class ManageBookingPageObject
    {
        private IWebDriver _webdriver;
        public readonly By _manageBooking = By.XPath("//div[@data-testid='Flights-horizontal-nav-tabs']");
        public readonly By _viewChangeAssistButton = By.XPath("//div[text()='View Change Assist']");

        public ManageBookingPageObject(IWebDriver webdriver)
        {
            _webdriver = webdriver;
        }
        public ManageBookingPageObject ManageBookingLinkClick()
        {
            _webdriver.FindElement(_manageBooking).Click();
            return new ManageBookingPageObject(_webdriver);
        }

        public ManageBookingPageObject ViewChangeAssistButtonAssertIsNotNull()
        {
            Assert.That(_viewChangeAssistButton, Is.Not.Null);
            return new ManageBookingPageObject (_webdriver);
        }
    }
}
