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
    public class ResponseExternalRepository : IResponseExternalRepository
    {
        
        private static string apiUrl = "https://api.shodan.io/shodan/host/search";
        
        public async Task<Response> GetByPhrase(string phrase)
        {
            var apiKey = Environment.GetEnvironmentVariable("API_KEY");
            
            var resultJson = await GetStringAsync(apiUrl + "?key=" + apiKey +"&query=" + phrase);
            
            return JsonConvert.DeserializeObject<Response>(resultJson);
        }
        
        private static async Task<string> GetStringAsync(string url)
        {
            using (var httpClient = new HttpClient())
            {
                return await httpClient.GetStringAsync(url);
            }
        }
    }
}