using System.Collections.Generic;
using Microsoft.CodeAnalysis;

namespace MassReconApi.Infrastucture.Model
{
    public class Location
    {
        public string City { get; set; }
        public string Country_name { get; set; } 
    }
    
    
    public class ShodanResponseItem
    {
        public string Data { get; set; }
        public string Ip_str { get; set; }
        public string Org { get; set; }

    }
}