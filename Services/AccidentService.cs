using Newtonsoft.Json;
using guvenport.Models;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Http;
using System.IO;
using guvenport.Models.Interface;

namespace guvenport.Services
{
    public class AccidentService : IAccidentService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _contextAccessor;

        public AccidentService(HttpClient httpClient, IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
            var httphelpernew = new httpHelpers();
            _httpClient = httphelpernew.HttpHelper(httpClient, contextAccessor);
        }

        public async Task<IEnumerable<AccidentDto>> ListAccidentsAsync()
        {
            var response = await _httpClient.GetAsync("api/accidents");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<AccidentDto>>(content) ?? new List<AccidentDto>();
            }
            return new List<AccidentDto>();
        }

        public async Task AddAccidentAsync(AccidentDto accident)
        {
            var json = JsonConvert.SerializeObject(accident);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/accidents", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task<AccidentDto?> GetAccidentByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/accidents/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<AccidentDto>(content);
            }
            return null;
        }

        public async Task<AccidentDto?> UpdateAccidentAsync(AccidentDto accident)
        {
            var json = JsonConvert.SerializeObject(accident);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"api/accidents/{accident.Id}", content);
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<AccidentDto>(responseContent);
            }
            return null;
        }

        public async Task<bool> DeleteAccidentAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/accidents/{id}");
            return response.IsSuccessStatusCode;
        }

    }
}
