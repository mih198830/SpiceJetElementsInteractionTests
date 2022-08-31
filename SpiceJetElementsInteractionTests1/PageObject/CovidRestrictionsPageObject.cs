using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiceJetElementsInteractionTests1.PageObject
{
    class CovidRestrictionsPageObject
    {
        private IWebDriver _webdriver;


        public CovidRestrictionsPageObject(IWebDriver webdriver)
        {
            _webdriver = webdriver;
        }
    }
}
