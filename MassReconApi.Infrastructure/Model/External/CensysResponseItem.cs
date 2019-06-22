using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Newtonsoft.Json;

namespace MassReconApi.Infrastucture.Model
{
     
    public class CensysResponseItem
    {
        public string Ip { get; set; }
        [JsonProperty(PropertyName = "Location.city")]
        public string City { get; set; }
    }
}