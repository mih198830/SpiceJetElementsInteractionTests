using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SpiceJetElementsInteractionTests1.PageObject
{
    class LoginPageObject
    {
        private IWebDriver _webdriver;
        private readonly By _loginButtonFromMainPage = By.XPath("//div[text()='Login']");
        private readonly By _loginButtonFromLoginMenu = By.XPath("//div[@data-testid='login-cta']");
        private readonly By _loginMenuPhoneNumber = By.XPath("//input[@data-testid='user-mobileno-input-box']");
        private readonly By _validationPhoneMessage = By.XPath("//div[text()='Please enter a valid mobile number']");
        

        public LoginPageObject(IWebDriver webdriver)
        {
            _webdriver = webdriver;
        }

        public LoginPageObject()
        {
        }

        public LoginPageObject LoginButtonFromMainPageClick()
        {
            _webdriver.FindElement(_loginButtonFromMainPage).Click();
            return new LoginPageObject(_webdriver);
        }

        public LoginPageObject ValidationPhoneMessageToText()
        {
            String validationPhoneMessage = _webdriver.FindElement(_validationPhoneMessage).Text;
            return new LoginPageObject(_webdriver);
        }

        public LoginPageObject LoginMenuRandomPhoneNumber()
        {
            string phoneNumber = Faker.Phone.Number();
            _webdriver.FindElement(_loginMenuPhoneNumber).SendKeys(phoneNumber);
            _webdriver.FindElement(_loginButtonFromLoginMenu).Click();
            String validationPhoneMessage = _webdriver.FindElement(_validationPhoneMessage).Text;
            Assert.AreEqual("Please enter a valid mobile number", validationPhoneMessage);
            return new LoginPageObject(_webdriver);
        }

        public LoginPageObject LoginButtonFromLoginMenuClick()
        {
            _webdriver.FindElement(_loginButtonFromLoginMenu).Click();
            return new LoginPageObject(_webdriver);
        }
    }
}
