using Newtonsoft.Json;
using guvenport.Models;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System;
using System.Net.Http;
using System.Text;
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
            _httpClient = httpClient;
            _contextAccessor = contextAccessor;
        }

        public async Task<IEnumerable<AccidentDto>> ListAccidentsAsync()
        {
            // Implementation here
            return new List<AccidentDto>();
        }

        public async Task AddAccidentAsync(AccidentDto accident)
        {
            // Implementation here
        }

        public async Task<AccidentDto?> GetAccidentByIdAsync(int id)
        {
            // Implementation here
            return null;
        }

        public async Task<AccidentDto?> UpdateAccidentAsync(AccidentDto accident)
        {
            // Implementation here
            return null;
        }

        public async Task<bool> DeleteAccidentAsync(int id)
        {
            // Implementation here
            return false;
        }
    }
}
