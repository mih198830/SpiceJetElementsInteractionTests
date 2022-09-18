using AngleSharp.Dom;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SpiceJetElementsInteractionTests1.PageObject
{
    class CheckInPageObject
    {
        
        private IWebDriver _webDriver;
        private readonly By _ticketNumber = By.CssSelector(".css-1cwyjr8.r-homxoj.r-ubezar.r-1eimq0t.r-1e081e0.r-xfkzu9.r-lnhwgy");
        private readonly By _emailField = By.XPath("//input[@placeholder='john.doe@spicejet.com']");
        private readonly By _searchBooking = By.XPath("//div[text()='Search Booking']");
       

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

        public CheckInPageObject TicketNumberFieldClick()
        {
            _webDriver.FindElement(_ticketNumber).Click();
            return new CheckInPageObject(_webDriver);
        }

    }
}
