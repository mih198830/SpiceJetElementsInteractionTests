using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace SpiceJetElementsInteractionTests1.PageObject
{
    class SightUpPageObject
    {
        private IWebDriver _webDriver;
        private readonly By _addonsLi = By.XPath("(//a[normalize-space()='Add-ons'])[2]");
        private readonly By _partnersLink = By.CssSelector("a[href='/partnersOverview']");
        private readonly By _creditCardLink = By.XPath("//a[normalize-space()='Credit Cards']");
        //a[normalize-space()='Credit Cards']

        public SightUpPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public SightUpPageObject FlightsLiClick()
        {
            _webDriver.FindElement(_addonsLi).Click();
            return new SightUpPageObject(_webDriver);
        }

        public SightUpPageObject PartnersLinkClick()
        {
            _webDriver.FindElement(_partnersLink).Click();
            return new SightUpPageObject(_webDriver);
        }

        public SightUpPageObject CreditCardsLinkClick()
        {
            _webDriver.FindElement(_creditCardLink).Click();
            return new SightUpPageObject(_webDriver);
        }
    }
}
