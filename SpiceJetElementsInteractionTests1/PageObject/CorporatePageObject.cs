using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace SpiceJetElementsInteractionTests1.PageObject
{
    class CorporatePageObject
    {
        private IWebDriver _webDriver;
        private readonly By _addonsDropDown = By.Id("highlight-addons");
        private readonly By _visaServicesLink = By.XPath("//div[text()='Visa Services']");

        public CorporatePageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

    }
}
