using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiceJetElementsInteractionTests1
{


        public class Rootobject
        {
            public string status { get; set; }
            public Data data { get; set; }
        }

        public class Data
        {
            public Popularstation[] popularStations { get; set; }
            public Station[] stations { get; set; }
        }

        public class Popularstation
        {
            public string stationCode { get; set; }
            public bool inActive { get; set; }
            public bool allowed { get; set; }
            public string icaoCode { get; set; }
            public string fullName { get; set; }
            public string shortName { get; set; }
            public object macCode { get; set; }
            public string currencyCode { get; set; }
            public object conversionCurrencyCode { get; set; }
            public string cultureCode { get; set; }
            public string _class { get; set; }
            public Locationdetails locationDetails { get; set; }
            public string airport { get; set; }
            public string aliasStations { get; set; }
        }

        public class Locationdetails
        {
            public Coordinates coordinates { get; set; }
            public string zoneCode { get; set; }
            public string subZoneCode { get; set; }
            public string countryCode { get; set; }
            public string provinceStateCode { get; set; }
            public string cityCode { get; set; }
            public string timeZoneCode { get; set; }
            public bool thirdPartyControlled { get; set; }
            public bool customsRequiredForCrew { get; set; }
            public int weightType { get; set; }
            public string country { get; set; }
        }

        public class Coordinates
        {
            public string latitude { get; set; }
            public string longitude { get; set; }
        }

        public class Station
        {
            public string stationCode { get; set; }
            public bool inActive { get; set; }
            public bool allowed { get; set; }
            public string icaoCode { get; set; }
            public string fullName { get; set; }
            public string shortName { get; set; }
            public string macCode { get; set; }
            public string currencyCode { get; set; }
            public string conversionCurrencyCode { get; set; }
            public string cultureCode { get; set; }
            public string _class { get; set; }
            public Locationdetails1 locationDetails { get; set; }
            public string airport { get; set; }
            public string aliasStations { get; set; }
        }

        public class Locationdetails1
        {
            public Coordinates1 coordinates { get; set; }
            public string zoneCode { get; set; }
            public string subZoneCode { get; set; }
            public string countryCode { get; set; }
            public string provinceStateCode { get; set; }
            public string cityCode { get; set; }
            public string timeZoneCode { get; set; }
            public bool thirdPartyControlled { get; set; }
            public bool customsRequiredForCrew { get; set; }
            public int weightType { get; set; }
            public string country { get; set; }
        }

        public class Coordinates1
        {
            public string latitude { get; set; }
            public string longitude { get; set; }
        }

    }
