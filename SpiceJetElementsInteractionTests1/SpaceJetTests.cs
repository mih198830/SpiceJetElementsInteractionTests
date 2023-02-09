using Newtonsoft.Json;
using NUnit.Framework;
using NUnit.Framework.Internal;
using SpiceJetElementsInteractionTests1.PageObject;
using System.Net;
using System;
using System.IO;

//Scenarios on the flight app https://www.spicejet.com/
//Could you automate dates - Valid, in valid, same date with different time
//From : Delhi, To: Chennai - Select a flight that starts post 12pm with cheapest fare from today until the next 3 days.

namespace SpiceJetElementsInteractionTests1
{
    public class Tests : BaseClass
    {

        [Test]
        public void CheapestFareFromTodayUntilNextThreeDays()
        {
            var flightsTab = new FlightsTabPageObject(_webDriver);
            var flightSearchTab = new FlightSearchPageObject(_webDriver);
            flightsTab.FlightsTabClick();
            flightsTab.FromFieldClick();
            flightsTab.DelhiAirportClick();
            flightsTab.ChennaiAirportClick();
            flightsTab.FromDatePlusOneDay();
            flightsTab.SearchFlightClick();
            flightSearchTab.getValueFromTimeOfFlight();
            var firstPrice = flightSearchTab.threeDaysLowestPriceSelect(0, 1);
            string secondPrice = flightSearchTab.threeDaysLowestPriceSelect(0, 2);
            string thirdPrice = flightSearchTab.threeDaysLowestPriceSelect(0, 3);

            var getLowestPriceWithDate = flightSearchTab.smallestPriceFromThreeDays(firstPrice, secondPrice, thirdPrice);

            flightSearchTab.SelectLowFlight(getLowestPriceWithDate);
        }

        [Test]
        public void searchEmptyDataViaApi()
        {
            string html;
            string url = "https://www.spicejet.com/api/v1/search/getStationDetails?getAllCities=true&getPopular=true";
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse();
            Stream stream = response.GetResponseStream();
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }

            var resp = JsonConvert.DeserializeObject<SingleUserResponseObject>(html);
            Assert.IsTrue(resp.data.id.Equals(2));
        }

    }

}
