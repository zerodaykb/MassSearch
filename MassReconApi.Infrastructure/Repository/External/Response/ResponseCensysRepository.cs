using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MassReconApi.Infrastucture.Context;
using MassReconApi.Infrastucture.Model;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace MassReconApi.Infrastucture.Repository
{   
    public class JsonContent : StringContent
    {
        public JsonContent(object obj) :
            base(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json")
        { }
    }
    
    public class ResponseCensysRepository : IResponseCensysRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;
        
        public ResponseCensysRepository(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        
        public async Task<CensysResponse> GetByPhrase(string phrase)
        {            
            var payload = new Dictionary<string, string>
            {
                { "query", phrase },
            };
            
            string strPayload = JsonConvert.SerializeObject(payload);
            HttpContent c = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");

            var client = _httpClientFactory.CreateClient("censys");

            var resultJson = client.PostAsync(client.BaseAddress, c).Result.Content.ReadAsStringAsync().Result;           
            var result = JsonConvert.DeserializeObject<CensysResponse>(resultJson);
            
            return result;
        }
    }
}