using SpiceJetElementsInteractionTests1;
using System;
using TechTalk.SpecFlow;
using SpiceJetElementsInteractionTests1.PageObject;
using OpenQA.Selenium;
using NUnit.Framework;

namespace SpecFlowSpiceJet.Specs.StepDefinitions
{
    [Binding]
    public class FlightTabDestinationFieldCheckStepDefinitions : BaseClass
    {
        String expectedTitle = "SpiceJet - Flight Booking for Domestic and International, Cheap Air Tickets";

        [When(@"I click '([^']*)' CTA")]
        public void WhenIClickCTA(string a)
        {
            var flightsTab = new FlightsTabPageObject(_webDriver);
            flightsTab.SearchFlightClick();
        }

        [Then(@"I see '([^']*)' pop up message appear")]
        public void ThenISeePopUpMessageAppear(string b)
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


        [When(@"I click '([^']*)'")]
        public void WhenIClick(string p0)
        {
            var manageBookingTab = new ManageBookingPageObject(_webDriver);
            manageBookingTab.ManageBookingLinkClick();
        }

        [Then(@"I check '([^']*)' button is no null")]
        public void ThenICheckButtonIsNoNull(string p0)
        {
            var manageBookingTab = new ManageBookingPageObject(_webDriver);
            manageBookingTab.ViewChangeAssistButtonAssertIsNotNull();
        }

        [When(@"I click '([^']*)' button")]
        public void WhenIClickButton(string search)
        {
            var flightsTab = new FlightsTabPageObject(_webDriver);
            flightsTab.SearchButtonClick();
            flightsTab.DismisButtonPresent();
        }

        [Then(@"I check that '([^']*)' button is present")]
        public void ThenICheckThatButtonIsPresent(string dISMISS)
        {
            var flightsTab = new FlightsTabPageObject(_webDriver);
            flightsTab.DismisButtonPresent();
        }

        [When(@"I click '([^']*)' link")]
        public void WhenIClickLink(string cOVID)
        {
            var flightsTab = new FlightsTabPageObject(_webDriver);
            flightsTab.CovidLinkClick();
        }

        [Then(@"Link opens")]
        public void ThenLinkOpens()
        {
            
        }

    }
}


