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

        public async Task<DtoListaEstado> GetEstados()
        {
            var httpResponse =  await _httpClient.GetAsync("https://covid19-brazil-api.now.sh/api/report/v1");
            var json = await httpResponse.Content.ReadAsStringAsync();
            // var convertido = JsonConvert.DeserializeObject<List<Estado>>(json);
            return JsonConvert.DeserializeObject<DtoListaEstado>(await httpResponse.Content.ReadAsStringAsync());
        }

        public async Task<DtoListaEstado> GetOlderEstados()
        {
            var httpResponse =  await _httpClient.GetAsync("https://covid19-brazil-api.now.sh/api/report/v1");
            var json = await httpResponse.Content.ReadAsStringAsync();
            // var convertido = JsonConvert.DeserializeObject<List<Estado>>(json);
            return JsonConvert.DeserializeObject<DtoListaEstado>(await httpResponse.Content.ReadAsStringAsync());
        }

        public async Task<Estado> GetStatusEstado()
        {
            var httpResponse =  await _httpClient.GetAsync(_httpClient.BaseAddress.AbsoluteUri);
            return JsonConvert.DeserializeObject<Estado>(await httpResponse.Content.ReadAsStringAsync());
        }
    }
}