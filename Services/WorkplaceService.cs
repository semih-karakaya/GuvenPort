using Microsoft.AspNetCore.Mvc;
using guvenport.Models.Interface;

namespace guvenport.Services
{
    public class WorkplaceService : IWorkplaceService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _contextAccessor;

        public WorkplaceService(HttpClient httpClient, IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
            var httphelpernew = new httpHelpers();
            _httpClient = httphelpernew.HttpHelper(httpClient, contextAccessor);
        }
        
    }
        
}
