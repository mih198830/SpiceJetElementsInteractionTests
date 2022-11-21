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
        private readonly By _clickContinueButton = By.XPath("//*[@data-testid='continue-search-page-cta']");
        private IWebElement getAmount(string dateFrom, string monthName) => _webdriver.FindElement(By.XPath($"//div[@data-testid='lowfare-calendar-dateId']//div[contains(text(),'{dateFrom} {monthName}')]//following::div[1]//div[2]"));
        private IWebElement ClickFlight(string dateFrom, string monthName) => _webdriver.FindElement(By.XPath($"//div[@data-testid='lowfare-calendar-dateId']//div[contains(text(),'{dateFrom} {monthName}')]//ancestor::div[@data-testid='lowfare-calendar-dateId']"));



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


        public string[] getSplitString(string text)
        {
            var getText = text.Split(" ");
            return getText;
        }
        public string smallestPriceFromThreeDays(string numberOne, string numberTwo, string numberThree)
        {
            var splitNumberOne = getSplitString(numberOne);
            var splitNumberTwo = getSplitString(numberTwo);
            var splitNumberThree = getSplitString(numberThree);
            var getNumberOne = int.Parse(splitNumberOne[0]);
            var getNumberTwo = int.Parse(splitNumberTwo[0]);
            var getNumberThree = int.Parse(splitNumberThree[0]);
            if ((getNumberThree < getNumberTwo) && (getNumberThree < getNumberOne))
            {
                return getNumberThree + " " + splitNumberThree[1];
            }
            else if ((getNumberTwo < getNumberOne) && (getNumberTwo < getNumberThree))
            {
                return getNumberTwo + " " + splitNumberTwo[1];
            }
            else
            {
                return getNumberOne + " " + splitNumberOne[1];
            }
        }

        public void SelectLowFlight(string priceWithDate)
        {
            var getDateAlone = priceWithDate.Split(" ");
            var splitMonthDate = getDateAlone[1].Split("-");
            ClickFlight(splitMonthDate[0], splitMonthDate[1]).Click();
            _webdriver.FindElement(_clickContinueButton).Click();
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
