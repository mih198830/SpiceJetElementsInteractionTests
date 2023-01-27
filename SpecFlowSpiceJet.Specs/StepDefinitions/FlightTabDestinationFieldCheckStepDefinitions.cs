using SpiceJetElementsInteractionTests1;
using System;
using TechTalk.SpecFlow;
using SpiceJetElementsInteractionTests1.PageObject;
using OpenQA.Selenium;
using NUnit.Framework;


//livingdoc feature-folder C:\Users\m.matskevich\source\repos\mih198830\SpiceJetElementsInteractionTests\SpecFlowSpiceJet.Specs -t "C:\Users\m.matskevich\source\repos\mih198830\SpiceJetElementsInteractionTests\SpecFlowSpiceJet.Specs\bin\Debug\net6.0\TestExecution.json"

namespace SpecFlowSpiceJet.Specs.StepDefinitions
{
    [Binding]
    public class FlightTabDestinationFieldCheckStepDefinitions : BaseClass
    {
        String expectedTitle = "SpiceJet - Flight Booking for Domestic and International, Cheap Air Tickets";

        [When(@"I click Search flight CTA")]
        public void WhenIClickCTA()
        {
            var flightsTab = new FlightsTabPageObject(_webDriver);
            flightsTab.SearchFlightClick();
        }

        [Then(@"I see Destination can not be empty pop up message appear")]
        public void ThenISeePopUpMessageAppear()
        {
            var flightsTab = new FlightsTabPageObject(_webDriver);
            flightsTab.DestinationCityPopUpDisplayed();
        }

        [When(@"I compare page title with expected value")]
        public void WhenIComparePageTitleWithExpectedValue()
        {
            String expectedTitle;
            String title;
        }

        [Then(@"actual title = expected title")]
        public void ThenActualTitleExpectedTitle()
        {
            String title = _webDriver.Title;
            Assert.That(title.Contains(expectedTitle), Is.EqualTo(true), "Title is not matching");
        }
        


        [When(@"I click Manage booking link")]
        public void WhenIClick()
        {
            var manageBookingTab = new ManageBookingPageObject(_webDriver);
            manageBookingTab.ManageBookingLinkClick();
        }

        [Then(@"I check View change assist button is no null")]
        public void ThenICheckButtonIsNoNull()
        {
            var manageBookingTab = new ManageBookingPageObject(_webDriver);
            manageBookingTab.ViewChangeAssistButtonAssertIsNotNull();
        }

        [When(@"I click Search button")]
        public void WhenIClickButton()
        {
            var flightsTab = new FlightsTabPageObject(_webDriver);
            flightsTab.SearchButtonClick();
            flightsTab.DismisButtonPresent();
        }
        

        [Then(@"I check that DISMISS button is present")]
        public void ThenICheckThatButtonIsPresent()
        {
            var flightsTab = new FlightsTabPageObject(_webDriver);
            flightsTab.DismisButtonPresent();
        }

        [When(@"I click COVID link")]
        public void WhenIClickCOVIDLink()
        {
            var flightsTab = new FlightsTabPageObject(_webDriver);
            flightsTab.CovidLinkClick();
        }


        [Then(@"Link opens")]
        public void ThenLinkOpens()
        {
            
        }

        [When(@"I click Check-in tab")]
        public void WhenIClickCheck_InTab()
        {
            var flightsTab = new FlightsTabPageObject(_webDriver);
            flightsTab.CheckInTabClick();
        }


        [When(@"I print random email address in email field")]
        public void WhenIPrintRandomEmailAddressInEmailField()
        {
            var checkInTab = new CheckInPageObject(_webDriver);
            checkInTab.SendRandomEmail();
        }

        [When(@"Clear printed text")]
        public void WhenClearPrintedText()
        {
            var checkInTab = new CheckInPageObject(_webDriver);
            checkInTab.ClearEmailField();
        }

        [Then(@"Text field email is cleared")]
        public void ThenTextFieldEmailIsCleared()
        {
            
        }

        [When(@"I click sign-up link")]
        public void WhenIClickSign_UpLink()
        {
            var signUp = new FlightsTabPageObject(_webDriver);
            signUp.SignUpClick();
            
        }

        [Then(@"Sign-up link opens in a new tab")]
        public void ThenSign_UpLinkOpensInANewTab()
        {
            var browserTabs = _webDriver.WindowHandles;
            _webDriver.SwitchTo().Window(browserTabs[1]);
            String CurrentUrl = _webDriver.Url;
            Assert.That(CurrentUrl, Is.EqualTo("https://spiceclub.spicejet.com/signup"));
        }

        [When(@"I click login button")]
        public void WhenIClickLoginButton()
        {
            var loginTab = new LoginPageObject(_webDriver);
            loginTab.LoginButtonFromMainPageClick();
            
        }

        [When(@"I Print randomly generated phone number to phone field and click login")]
        public void WhenIPrintRandomlyGeneratedPhoneNumberToPhoneFieldAndClickLogin()
        {
            var loginTab = new LoginPageObject(_webDriver);
            loginTab.LoginMenuRandomPhoneNumber();
        }

        [Then(@"Validation message about non existing phone number appear")]
        public void ThenValidationMessageAboutNonExistingPhoneNumberAppear()
        {

        }

        [When(@"I make page screenshot and save it locally as png")]
        public void WhenIMakePageScreenshotAndSaveItLocallyAsPng()
        {
            var flightsTab = new FlightsTabPageObject(_webDriver);
            
            flightsTab.MakeMainPageScreenshot();
        }

        [When(@"Get text from this screenshot")]
        public void WhenGetTextFromThisScreenshot()
        {
            var flightsTab = new FlightsTabPageObject(_webDriver);
            flightsTab.GetTextFromScreenshot();
        }

        [Then(@"I compare text with expected text")]
        public void ThenICompareTextWithExpectedText()
        {
            String expectedTextFromImage = "on hotel";
            var flightsTab = new FlightsTabPageObject(_webDriver);
            //Assert.That(flightsTab.GetTextFromScreenshot, Does.Contain(expectedTextFromImage));
        }

        [When(@"I click Flights Tab")]
        public void WhenIClickFlightsTab()
        {
            var checkInTab = new CheckInPageObject(_webDriver);
            var flightsTab = new FlightsTabPageObject(_webDriver);
            var flightSearchTab = new FlightSearchPageObject(_webDriver);
            var signUpLink = new SightUpPageObject(_webDriver);
            flightsTab.FlightsTabClick();
        }

        [When(@"I click One way radio button")]
        public void WhenIClickOneWayRadioButton()
        {
            var flightsTab = new FlightsTabPageObject(_webDriver);
            flightsTab.OneWayButtonClickAssert();
        }

        [When(@"I click round trip radio button")]
        public void WhenIClickRoundTripRadioButton()
        {
            var flightsTab = new FlightsTabPageObject(_webDriver);
            flightsTab.RoundTripRadioButtonClick();
        }

        [When(@"I click From field")]
        public void WhenIClickFromField()
        {
            var flightsTab = new FlightsTabPageObject(_webDriver);
            flightsTab.FromFieldClick();
        }

        [When(@"I select random from Airport")]
        public void WhenISelectRandomFromAirport()
        {
            var flightsTab = new FlightsTabPageObject(_webDriver);
            flightsTab.randomAirportFromArr();
        }

        [When(@"I select random to Airport")]
        public void WhenISelectRandomToAirport()
        {
            var flightsTab = new FlightsTabPageObject(_webDriver);
            flightsTab.randomAirportToArr();
        }

        [When(@"I select random From date")]
        public void WhenISelectRandomFromDate()
        {
            var flightsTab = new FlightsTabPageObject(_webDriver);
            flightsTab.FromDateSelect();
        }

        [When(@"I select random To date")]
        public void WhenISelectRandomToDate()
        {
            var flightsTab = new FlightsTabPageObject(_webDriver);
            flightsTab.ToDateSelect();
        }

        [When(@"I click Nuber of travallers dropdown")]
        public void WhenIClickNuberOfTravallersDropdown()
        {
            var flightsTab = new FlightsTabPageObject(_webDriver);
            flightsTab.NumberOfTravellersDropDownClick();
        }

        [When(@"I add one more adult passanger")]
        public void WhenIAddOneMoreAdultPassanger()
        {
            var flightsTab = new FlightsTabPageObject(_webDriver);
            flightsTab.NumberOfAdultsAddOne();
        }

        [When(@"I add (.*) more adults")]
        public void WhenIAddMoreAdults(int p0)
        {
            var flightsTab = new FlightsTabPageObject(_webDriver);
            flightsTab.NumberOfAdultsUptToSevenClick();
        }

        [When(@"I click currency")]
        public void WhenIClickCurrency()
        {
            var flightsTab = new FlightsTabPageObject(_webDriver);
            flightsTab.CurrencyClick();
        }

        [When(@"I check that USD currency is selected")]
        public void WhenICheckThatUSDCurrencyIsSelected()
        {
            var flightsTab = new FlightsTabPageObject(_webDriver);
            flightsTab.UsdCurrencyClickAndAssert();
        }

        [When(@"I click flights link")]
        public void WhenIClickFlightsLink()
        {
            var signUpLink = new SightUpPageObject(_webDriver);
            var browserTabs = _webDriver.WindowHandles;
            _webDriver.SwitchTo().Window(browserTabs[1]);
            signUpLink.FlightsLiClick();
        }

        [When(@"I click partners link")]
        public void WhenIClickPartnersLink()
        {
            var signUpLink = new SightUpPageObject(_webDriver);
            signUpLink.PartnersLinkClick();
        }

        [When(@"I click Credit Cards link")]
        public void WhenIClickCreditCardsLink()
        {
            var signUpLink = new SightUpPageObject(_webDriver);
            signUpLink.CreditCardsLinkClick();
        }

        [Then(@"I see Credit card link is opened as last opened link")]
        public void ThenISeeCreditCardLinkIsOpenedAsLastOpenedLink()
        {
            
        }


    }
}


