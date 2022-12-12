using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace SpiceJetElementsInteractionTests1.Steps
{
    [Binding]
    public class TitleCheckStepDefinitions : BaseClass
    {
        [Given(@"I have expected title for the site spicejet\.com saved")]
        public void GivenIHaveExpectedTitleForTheSiteSpicejet_ComSaved()
        {
            String expectedTitle = "SpiceJet - Flight Booking for Domestic and International, Cheap Air Tickets";
        }

        [When(@"i save site spicejet\.com title to actual result variable")]
        public void WhenISaveSiteSpicejet_ComTitleToActualResultVariable()
        {
            String title = _webDriver.Title;
        }

        [Then(@"actual text title is equal to expected title")]
        public void ThenActualTextTitleIsEqualToExpectedTitle()
        {
            Assert.That(_webDriver.Title.Contains("SpiceJet - Flight Booking for Domestic and International, Cheap Air Tickets"), Is.EqualTo(true), "Title is not matching");
        }
    }
}
