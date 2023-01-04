using OpenQA.Selenium;
using System.Dynamic;
using IronOcr;
using static Akka.IO.Tcp;
using OpenQA.Selenium.Support.UI;
using AngleSharp.Dom;
using System.Runtime.InteropServices;
using System.Globalization;
using Microsoft.VisualBasic;

//first simply we can just check the time of lowest flight we selected , if it's past 12 then nothing to change
//if not
//get all flights from day1 which past 12 - get all amount  - find the lowest and store it in varaiable
//get all flights from day2 which past 12 - get all amount  - find the lowest and store it in varaiable
//get all flights from day3 which past 12 - get all amount  - find the lowest and store it in varaiable
//compare all three varaibale , pick the lowest and select flight

//*[text()='Flight Details']//preceding::div[2]

//found the shortest to get time
//all time in that page
//get text in that xpath
//*[text()='12:45']//following::div[@data-testid='spicesaver-flight-select-radio-button-1']//following::div[2]
//pass that time
//above will get amount
//to pass those 6 texts times instead 12:45, in the example, right?


namespace SpiceJetElementsInteractionTests1.PageObject
{
    class FlightSearchPageObject
    {
        private IWebDriver _webdriver;
        private readonly By _modifySearchButton = By.XPath("//span[@dir='auto']//div[@data-focusable='true']");
        private readonly By _searchAgainButton = By.XPath("//*[@data-testid='home-page-flight-cta']");
        private readonly By _signUpButton = By.XPath("//div[text()='Signup']");
        private IWebElement _continueButton => _webdriver.FindElement(By.Id("replacedbutton"));

        private IWebElement getAmount(string dateFrom, string monthName) => _webdriver.FindElement(By.XPath($"//div[@data-testid='lowfare-calendar-dateId']//div[contains(text(),'{dateFrom} {monthName}')]//following::div[1]//div[2]"));

        private IWebElement ClickFlight(string dateFrom, string monthName) => _webdriver.FindElement(By.XPath($"//div[@data-testid='lowfare-calendar-dateId']//div[contains(text(),'{dateFrom} {monthName}')]//ancestor::div[@data-testid='lowfare-calendar-dateId']"));
        private IList<IWebElement> getTime => _webdriver.FindElements(By.XPath("//div[text()='Flight Details']//preceding::div[2]"));
        private IWebElement amountWithTime(string getValueFromTimeOfFlight) => _webdriver.FindElement(By.XPath($"*[text()='{getValueFromTimeOfFlight}']//following::div[@data-testid='spicesaver-flight-select-radio-button-1']//following::div[2]"));


        public FlightSearchPageObject(IWebDriver webdriver)
        {
            _webdriver = webdriver;
        }


        public async DateTime getValueFromTimeOfFlight()
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

                if (t1.TimeOfDay > t2.TimeOfDay)
                {
                    Console.WriteLine(t1);
                }
            }
            return t1;
        
        }

        public void getPriceFromFlight()
        {
            //amountWithTime().Click();

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

