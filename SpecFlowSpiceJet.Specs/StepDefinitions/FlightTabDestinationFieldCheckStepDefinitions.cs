using SpiceJetElementsInteractionTests1;
using System;
using TechTalk.SpecFlow;
using SpiceJetElementsInteractionTests1.PageObject;
using OpenQA.Selenium;

namespace SpecFlowSpiceJet.Specs.StepDefinitions
{
    [Binding]
    public class FlightTabDestinationFieldCheckStepDefinitions : BaseClass
    {

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
    }
}
