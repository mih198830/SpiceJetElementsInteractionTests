using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using SpiceJetElementsInteractionTests1.PageObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace SpiceJetElementsInteractionTests1
{
    namespace SpiceJetElementsInteractionTests1
    {
        public class Tests
        {
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

                var resp = JsonConvert.DeserializeObject<Rootobject>(html);
                Assert.IsTrue(resp.status.Equals("SUCCESS"));
            }

            private RestClient _client;

            [SetUp]
            public void Setup()
            {
                _client = new RestClient("https://www.spicejet.com/api/v3/search/availability");
            }
            [Test]
            public void ShouldReturnAvailableFlights()
            {
                // Arrange
                var request = new RestRequest("availability", Method.Post);
                request.AddHeader("Content-Type", "application/json");
                request.AddJsonBody(new
                {
                    originStationCode = "DEL",
                    destinationStationCode = "BOM",
                    onWardDate = "2023 - 02 - 27",
                    currency = "INR",
                    pax = request.AddJsonBody(new
                    {
                        journeyClass = "ff",
                        adult = 1,
                        child = 0,
                        infant = 0,
                        srCitizen = 0
                    })
                });

                // Act
                RestResponse response = _client.Execute(request);

                // Assert
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(response.Content, Does.Contain("data"));
            }
        }

    }
}

