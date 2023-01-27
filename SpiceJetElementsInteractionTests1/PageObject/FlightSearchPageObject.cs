using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace SpiceJetElementsInteractionTests1.PageObject
{
    public class FlightSearchPageObject
    {
        private IWebDriver _webdriver;
        private readonly By _modifySearchButton = By.XPath("//span[@dir='auto']//div[@data-focusable='true']");
        private readonly By _searchAgainButton = By.XPath("//*[@data-testid='home-page-flight-cta']");
        private readonly By _signUpButton = By.XPath("//div[text()='Signup']");
        private IWebElement _continueButton => _webdriver.FindElement(By.Id("replacedbutton"));

        private IWebElement getAmount(string dateFrom, string monthName) => _webdriver.FindElement(By.XPath($"//div[@data-testid='lowfare-calendar-dateId']//div[contains(text(),'{dateFrom} {monthName}')]//following::div[1]//div[2]"));

        private IWebElement ClickFlight(string dateFrom, string monthName) => _webdriver.FindElement(By.XPath($"//div[@data-testid='lowfare-calendar-dateId']//div[contains(text(),'{dateFrom} {monthName}')]//ancestor::div[@data-testid='lowfare-calendar-dateId']"));
        private IList<IWebElement> getTime => _webdriver.FindElements(By.XPath("//div[text()='Flight Details']//preceding::div[2]"));
        private IWebElement amountWithTime(string t1) => _webdriver.FindElement(By.XPath($"*[text()='{t1}']//following::div[@data-testid='spicesaver-flight-select-radio-button-1']//following::div[2]"));


        public FlightSearchPageObject(IWebDriver webdriver)
        {
            _webdriver = webdriver;
        }


        public async void getValueFromTimeOfFlight()
        {
            WebDriverWait wait = new WebDriverWait(_webdriver, TimeSpan.FromSeconds(10));
            wait.Until(x => x.FindElements(By.XPath("//div[text()='Flight Details']//preceding::div[2]")));
            String[] allTextForTime = new String[getTime.Count];
            int i = 0;
            DateTime t1 = DateTime.Parse(allTextForTime[i]);
            DateTime t2 = DateTime.Parse("12:00");
            foreach (IWebElement element in getTime)
            {
                allTextForTime[i++] = element.Text;

            }
            //    var lowestamount = 0;
            //    var newamount;
            //    for ()
            //    {
            //        if (t1.TimeOfDay > t2.TimeOfDay) && (lowestamount == 0);
            //        {
            //            private IWebElement lowestAmount(string t1) => _webdriver.FindElement(By.XPath($"*[text()='{t1}']//following::div[@data-testid='spicesaver-flight-select-radio-button-1']//following::div[2]"));
            //        }
            //        else
            //        {
            //            xpath to get amount, store this as new amount
            //        }
            //        if (lowestamount > newamount)
            //        {
            //            lowestamount = newamount;
            //        }
            //    }
            //    return lowestAmount;
            //}
        }


        public void getPriceFromFlight()
        {
         

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
            Thread.Sleep(3000);
            ClickFlight(splitMonthDate[0], splitMonthDate[1]).Click();
            Thread.Sleep(3000);
            _continueButton.Click();
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

