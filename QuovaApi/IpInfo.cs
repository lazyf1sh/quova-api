using System;
using System.Xml.Serialization;

namespace QuovaApi
{
    [Serializable()]
    [XmlRoot("ipinfo", Namespace = "http://data.quova.com/1", IsNullable = false)]
    public class IpInfo
    {
        public string ip_address { get; set; }
        public string ip_type { get; set; }
        public ipinfoNetWork Network { get; set; }
        public ipinfoLocation Location { get; set; }
    }

    public class ipinfoNetWork
    {
        public string organization { get; set; }
        public string carrier { get; set; }
        public string asn { get; set; }
        public string connection_type { get; set; }
        public string line_speed { get; set; }
        public string ip_routing_type { get; set; }
        public ipinfoNetWorkDomain Domain { get; set; }
    }

    public class ipinfoNetWorkDomain
    {
        public string tld { get; set; }
        public string sld { get; set; }
    }

    public class ipinfoLocation
    {
        public string continent { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public ipinfoLocationCountryData CountryData { get; set; }
        public string region { get; set; }
        public ipinfoLocationStateData StateData { get; set; }
        public string dma { get; set; }
        public string msa { get; set; }
        public ipinfoLocationCityData CityData { get; set; }
    }

    public class ipinfoLocationCountryData
    {
        public string country { get; set; }
        public string country_code { get; set; }
        public string country_cf { get; set; }
    }
    public class ipinfoLocationStateData
    {
        public string state { get; set; }
        public string state_code { get; set; }
        public string state_cf { get; set; }
    }
    public class ipinfoLocationCityData
    {
        public string city { get; set; }
        public string postal_code { get; set; }
        public string time_zone { get; set; }
        public string area_code { get; set; }
        public string city_cf { get; set; }
    }

}
