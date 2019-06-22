using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MassReconApi.Infrastucture.Context;
using MassReconApi.Infrastucture.Model;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace MassReconApi.Infrastucture.Repository
{   
    public class ResponseShodanRepository : IResponseShodanRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;
        
        public ResponseShodanRepository(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        
        public async Task<ShodanResponse> GetByPhrase(string phrase)
        {
            var apiKey = Environment.GetEnvironmentVariable("SHODAN_API_KEY");
            
            var client = _httpClientFactory.CreateClient("shodan");
            var resultJson = await client.GetStringAsync(client.BaseAddress + "?key=" + apiKey + "&query=" + phrase);
            var result = JsonConvert.DeserializeObject<ShodanResponse>(resultJson);
            
            return result;
        }
    }
}