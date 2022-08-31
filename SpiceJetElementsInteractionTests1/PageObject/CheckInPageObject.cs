using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiceJetElementsInteractionTests1.PageObject
{
    class CheckInPageObject
    {
        private IWebDriver _webDriver;
        private readonly By _ticketNumber = By.CssSelector(".css-1cwyjr8.r-homxoj.r-ubezar.r-1eimq0t.r-1e081e0.r-xfkzu9.r-lnhwgy");
        private readonly By _emailField = By.XPath("//input[@placeholder='john.doe@spicejet.com']");



        public CheckInPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public CheckInPageObject TicketNumberSendKeys()
        {
            string ticketNumber = Faker.Phone.Number().Replace("+", "").Replace("(", "").Replace(")", "").Replace("-", "");
            _webDriver.FindElement(_ticketNumber).SendKeys(ticketNumber);
            return new CheckInPageObject(_webDriver);
        }

        public CheckInPageObject SendRandomEmail()
        {
            // Generate random email using Faker API //
            string email = Faker.Internet.Email();
            _webDriver.FindElement(_emailField).SendKeys(email);
            return new CheckInPageObject(_webDriver);
        }
        
        public CheckInPageObject ClearEmailField()
        {
            _webDriver.FindElement(_emailField).Clear();
            return new CheckInPageObject(_webDriver);
        }

    }
}
