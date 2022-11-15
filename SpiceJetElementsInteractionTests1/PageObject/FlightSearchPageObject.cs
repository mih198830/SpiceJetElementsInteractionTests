using OpenQA.Selenium;
using System.Dynamic;

namespace SpiceJetElementsInteractionTests1.PageObject
{
    class FlightSearchPageObject
    {
        
        private IWebDriver _webdriver;
        private readonly By _modifySearchButton = By.XPath("//span[@dir='auto']//div[@data-focusable='true']");
        private readonly By _searchAgainButton = By.XPath("//*[@data-testid='home-page-flight-cta']");
        private readonly By _signUpButton = By.XPath("//div[text()='Signup']");
        //public IList<IWebElement> _spiceSavePriceFlights => _webdriver.FindElements(By.XPath("//div[contains(@data-testid,'spicesaver-flight')]//following::div[2]"));
        private IWebElement getAmount(string dateFrom, string monthName) => _webdriver.FindElement(By.XPath($"//div[@data-testid='lowfare-calendar-dateId']//div[contains(text(),'{dateFrom} {monthName}')]//following::div[1]//div[2]"));
        


        public FlightSearchPageObject(IWebDriver webdriver)
        {
            _webdriver = webdriver;
        }

        public string threeDaysLowestPriceSelect(int monthsFromToday, int daysFromToday)
        {
            DateTime dateForMonthSelection = DateTime.Now.AddDays(monthsFromToday);
            DateTime dateForDateSelectionFrom = DateTime.Now.AddDays(daysFromToday);
            string monthName = dateForMonthSelection.ToString("MMM");
            string dateFrom = dateForDateSelectionFrom.ToString("dd");
            var amount = getAmount(dateFrom, monthName);
            var amountText = amount.Text;
            return amountText;

        }

        public int smallestPriceFromThreeDays(int numberOne, int numberTwo, int numberThree)
        {
            if ((numberThree < numberTwo) && (numberThree < numberOne))
            {
                return numberThree;
            }
            else if ((numberTwo < numberOne) && (numberTwo < numberThree))
            {
                return numberTwo;
            }
            else
            {
                return numberOne;
            }
        }

        public FlightSearchPageObject _lowfareCalendarPlusDays()
        {
            DateTime dateForMonthSelection = DateTime.Now.AddDays(0);
            DateTime dateForDateSelectionFrom = DateTime.Now.AddDays(1);
            string monthName = dateForMonthSelection.ToString("MMM");
            string dateFrom = dateForDateSelectionFrom.ToString("%d");
            _webdriver.FindElement(By.XPath($"/div[@data-testid='lowfare-calendar-dateId']//div[contains(text(),'{dateFrom} {monthName}')]"));
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
