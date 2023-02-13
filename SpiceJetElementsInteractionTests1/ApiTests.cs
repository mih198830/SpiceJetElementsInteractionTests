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

            [Test]
            public void StatusCodeTest()
            {
                // arrange
                RestClient client = new RestClient("http://api.zippopotam.us");
                RestRequest request = new RestRequest("nl/3825", Method.Get);

                // act
                IRestResponse response = client.Execute(request);

                // assert
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            }
        }



    }

}
