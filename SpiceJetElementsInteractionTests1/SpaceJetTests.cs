using OpenQA.Selenium;
using Bogus;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


//August 2022 changelog
//- Used https://github.com/rosolko/WebDriverManager.Net so Firefox browser is working now (+ Chrome)
//automatically downloads browser version and keeps updated
// - Replaced all Thread.Sleep with one line Implicit Wait timeout
// - Added FOR loop for 6 adults selection
// - Added Faker library usage for ticket number / Email generation
// - Updated Airports selectors to 3 letters (find by text)

// - OpenQA.Selenium - namespace with classes, interfaces, methods for different browsers (Chrome, Firefox, etc)
// https://www.selenium.dev/selenium/docs/api/java/org/openqa/selenium/package-summary.html
// - Added title test
// - radio-button assert added one-way trip


namespace SpiceJetElementsInteractionTests1
{
    [TestFixture]
    public class Tests : BaseClass
    {
        private readonly By _numberOfChildren = By.CssSelector("div[data-testid='Children-testID-plus-one-cta']");
        private readonly By _oneWayTripRadioButton = By.XPath("//div[@data-testid='one-way-radio-button']");

        [Test]
        public void RoundTripRadioButtonClick()
        {

            String expectedTitle = "SpiceJet - Flight Booking for Domestic and International, Cheap Air Tickets";
            String title = _webDriver.Title;
            Assert.That(title.Contains(expectedTitle), Is.EqualTo(true), "Title is not matching");


            // open COVID-19 rules link in new tab // retrieve info 
            _webDriver.FindElement(By.XPath("//div[text()='COVID-19 Information']")).Click();
            
            // switch to first tab
            ((IJavaScriptExecutor)_webDriver).ExecuteScript("window.open()");
            List<string> tabs = new List<string>(_webDriver.WindowHandles);
            _webDriver.SwitchTo().Window(tabs[0]);

            // checkIn tab click
            _webDriver.FindElement(By.XPath("//div[@data-testid='check-in-horizontal-nav-tabs']")).Click();

            // send keys (ticket number) CSS // add ticket generator//validation numbers//
            string ticketNumber = Faker.Phone.Number().Replace("+", "").Replace("(", "").Replace(")", "").Replace("-", "");
            _webDriver.FindElement(By.CssSelector(".css-1cwyjr8.r-homxoj.r-ubezar.r-1eimq0t.r-1e081e0.r-xfkzu9.r-lnhwgy")).SendKeys(ticketNumber);

            // Generate random email using Faker API //
            string email = Faker.Internet.Email();
            _webDriver.FindElement(By.XPath("//input[@placeholder='john.doe@spicejet.com']")).SendKeys(email);

            // manage booking nav tab click
            _webDriver.FindElement(By.XPath("//div[@data-testid='manage booking-horizontal-nav-tabs']")).Click();

            // flights horizontal tab click
            _webDriver.FindElement(By.XPath("//div[@data-testid='Flights-horizontal-nav-tabs']")).Click();

            //round trip radio button click
            _webDriver.FindElement(By.XPath("//div[@data-testid='round-trip-radio-button']")).Click();

            //one way radio button click
            var oneWayRadioButton = _webDriver.FindElement(_oneWayTripRadioButton);
            oneWayRadioButton.Click();
            Assert.That(oneWayRadioButton.Selected, Is.EqualTo(false));

            //from field click
            _webDriver.FindElement(By.XPath("//div[@data-testid='to-testID-origin']")).Click();

            //flying from Mumbai airport selection
            _webDriver.FindElement(By.XPath("//div[text()='BOM']")).Click();

            //flying to Agra airport selection
            _webDriver.FindElement(By.XPath("//div[text()='AGR']")).Click();

            //change from and to destination arrow click
            _webDriver.FindElement(By.XPath("//div[@data-testid='to-testID-flip-arrow']")).Click();

            //to field destination click
            _webDriver.FindElement(By.XPath("//div[@data-testid='to-testID-destination']")).Click();

            //international destination selection click
            _webDriver.FindElement(By.XPath("//div[text()='International']")).Click();

            //select Bangkok airport
            _webDriver.FindElement(By.XPath("//div[text()='BKK']")).Click();

            //select FROM date USING CSS
            _webDriver.FindElement(By.CssSelector("div[data-testid='undefined-month-August-2022'] [data-testid='undefined-calendar-day-31']")).Click();

            //click return date date picker CSS
            _webDriver.FindElement(By.CssSelector("div[data-testid='return-date-dropdown-label-test-id']")).Click();

            _webDriver.FindElement(By.CssSelector("div[data-testid='undefined-month-September-2022'] [data-testid='undefined-calendar-day-30']")).Click();

            _webDriver.FindElement(By.CssSelector("div[data-testid='home-page-travellers']")).Click();
 
            //double click number of children CSS
            var numberOfChildren = _webDriver.FindElement(_numberOfChildren);
            numberOfChildren.Click();

            //Five clicks to add 5 more adult passengers CSS
            for(int i = 1; i<6; i++)
            {
                _webDriver.FindElement(By.CssSelector("div[data-testid='Adult-testID-plus-one-cta']")).Click();
            }

            // currency drop-down click
            _webDriver.FindElement(By.XPath("//div[text()='Currency']")).Click();

            // currency USD Xpath selector click
            _webDriver.FindElement(By.XPath("//div[text()='USD']")).Click();

            String CurrencyUSD = _webDriver.FindElement(By.XPath("//div[text()='USD']")).Text;
            Assert.AreEqual("USD", CurrencyUSD);
            

            //students Radio button css selector click
            //Assert for selection added
            _webDriver.FindElement(By.XPath("//div[text()='Students']")).Click();
            String ChoosedRadioButton =_webDriver.FindElement(By.XPath("//div[text()='Students']")).Text;
            Assert.That("Students", Is.EqualTo(ChoosedRadioButton));

            //search Flight button xpath button click
            _webDriver.FindElement(By.XPath("//div[@data-testid='home-page-flight-cta']")).Click();
        }
    }
}