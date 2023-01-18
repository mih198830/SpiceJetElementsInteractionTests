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
        public void WhenIClickCTA()
        {
            String expectedTitle = "SpiceJet - Flight Booking for Domestic and International, Cheap Air Tickets";
            String title = _webDriver.Title;
            var flightsTab = new FlightsTabPageObject(_webDriver);

            flightsTab.SearchFlightClick();
            
            throw new PendingStepException();
        }

        [Then(@"I see '([^']*)' pop up message appear")]
        public void ThenISeePopUpMessageAppear(string p0)
        {
            var flightsTab = new FlightsTabPageObject(_webDriver);
            flightsTab.DestinationCityPopUpDisplayed();
            throw new PendingStepException();
        }
    }
}
