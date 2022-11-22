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
        private readonly By _continueButton = By.XPath("//div[@data-testid='continue-search-page-cta'][@id='button']");
        private IWebElement getAmount(string dateFrom, string monthName) => _webdriver.FindElement(By.XPath($"//div[@data-testid='lowfare-calendar-dateId']//div[contains(text(),'{dateFrom} {monthName}')]//following::div[1]//div[2]"));

        //private IWebElement ClickFlight(string dateFrom, string monthName) => _webdriver.FindElement(By.XPath($"//div[@data-testid='lowfare-calendar-dateId']//div[contains(text(),'{dateFrom} {monthName}')]//ancestor::div[@data-testid='lowfare-calendar-dateId']"));
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
            var saveDate = dateFrom + "-" + monthName;
            return amountText + " " + saveDate;
        }
        public string getAmountAlone(string text)
        {
            var getAmountText = text.Split(" ")[0];
            return getAmountText.Replace(",", "");
        }
        public string getDateAlone(string text)
        {
            var getDateText = text.Split(" ")[1];
            return getDateText;
        }
        public string smallestPriceFromThreeDays(string numberOne, string numberTwo, string numberThree)
        {
            var getNumberOne = int.Parse(getAmountAlone(numberOne));
            var getNumberTwo = int.Parse(getAmountAlone(numberTwo));
            var getNumberThree = int.Parse(getAmountAlone(numberThree));
            if ((getNumberThree < getNumberTwo) && (getNumberThree < getNumberOne))
            {
                return getNumberThree + " " + getDateAlone(numberThree);
            }
            else if ((getNumberTwo < getNumberOne) && (getNumberTwo < getNumberThree))
            {
                return getNumberTwo + " " + getDateAlone(numberTwo);
            }
            else
            {
                return getNumberOne + " " + getDateAlone(numberOne);
            }
        }
        public void SelectLowFlight(string priceWithDate)
        {
            var getDateAlone = priceWithDate.Split(" ");
            var splitMonthDate = getDateAlone[1].Split("-");
            ClickFlight(splitMonthDate[0], splitMonthDate[1]).Click();
            _webdriver.FindElement(_continueButton).Click();
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

