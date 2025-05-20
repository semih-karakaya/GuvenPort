using guvenport.Models.Interface;
using guvenport.Services;
using Microsoft.Extensions.DependencyInjection;

namespace guvenport.Services.IoC
{
    public static class ServiceContainer
    {

        public static void AddScopedService(this IServiceCollection services)
        {
            // Add all services here
  
            services.AddScoped<IAccidentService, AccidentService>();
           
            // Add other services as needed
        }
    }
}