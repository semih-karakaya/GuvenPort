﻿using guvenport.Models.Interface;

namespace guvenport.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _contextAccessor;

        public EmployeeService(HttpClient httpClient, IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
            var httphelpernew = new httpHelpers();
            _httpClient = httphelpernew.HttpHelper(httpClient, contextAccessor);
        }
    }
}
