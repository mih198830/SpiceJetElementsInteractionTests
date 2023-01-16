using System;
using TechTalk.SpecFlow;

namespace SpecFlowSpiceJet.Specs.StepDefinitions
{
    [Binding]
    public class FlightTabDestinationFieldCheckStepDefinitions
    {
        [When(@"I click '([^']*)' CTA")]
        public void WhenIClickCTA(string p0)
        {
            throw new PendingStepException();
        }

        [Then(@"I see '([^']*)' pop up message appear")]
        public void ThenISeePopUpMessageAppear(string p0)
        {
            throw new PendingStepException();
        }
    }
}
