using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CovidInfo.Models;
using CovidInfo.Services.Interfaces;
using Newtonsoft.Json;

namespace CovidInfo.Services.Implementation
{
    public class CovidService : ICovidService
    {
        private readonly HttpClient _httpClient;

        public CovidService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Estado> GetStatusEstados()
        {
            var httpResponse =  await _httpClient.GetAsync(_httpClient.BaseAddress.AbsoluteUri);
            return JsonConvert.DeserializeObject<Estado>(await httpResponse.Content.ReadAsStringAsync());

        }
    }
}