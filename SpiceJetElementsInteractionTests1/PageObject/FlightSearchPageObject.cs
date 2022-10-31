using OpenQA.Selenium;

namespace SpiceJetElementsInteractionTests1.PageObject
{
    class FlightSearchPageObject
    {
        private IWebDriver _webdriver;
        private readonly By _modifySearchButton = By.XPath("//span[@dir='auto']//div[@data-focusable='true']");
        private readonly By _searchAgainButton = By.XPath("//*[@data-testid='home-page-flight-cta']");
        private readonly By _signUpButton = By.XPath("//div[text()='Signup']");
        //private readonly By _spiceSavePriceFlights = By.XPath("//div[contains(@data-testid,'spicesaver-flight')]//following::div[2]");
        public List<IWebElement> _spiceSavePriceFlights => _webdriver.FindElements(By.XPath("//div[contains(@data-testid,'spicesaver-flight')]//following::div[2]"));

        private readonly By _lowfareCalendar = By.XPath("/div[@data-testid='lowfare-calendar-dateId']//div[contains(text(),'03 Nov')]");
            

        public FlightSearchPageObject(IWebDriver webdriver)
        {
            _webdriver = webdriver;
        }

        public FlightSearchPageObject SpiceSaverLowestPriceSelect()
        {
            _webdriver.FindElement(_lowfareCalendar).Click();
            IList<string> all = new List<string>();
            List<long> spiceSavePrices = new List<long>();

            //spiceSavePrices.Add(_spiceSavePriceFlights.Texts());
            spiceSavePrices.Add(_spiceSavePriceFlights.GetAttribute("textContent").Trim().ToList());
            
            long min_price = spiceSavePrices.AsQueryable().Min();
            return new FlightSearchPageObject(_webdriver);
        }
           

        public FlightSearchPageObject ModifySearchButtonClick()
        {
            _webdriver.FindElement(_modifySearchButton).Click();
            return new FlightSearchPageObject(_webdriver);
        }

        public FlightSearchPageObject SignUpButtonClick()
        {
            _webdriver.FindElement(_signUpButton).Click();
            return new FlightSearchPageObject(_webdriver);
        }

        public FlightSearchPageObject SearchFlightAgainButtonClick()
        {
            _webdriver.FindElement(_searchAgainButton).Click();
            return new FlightSearchPageObject(_webdriver);
        }
    }
}
