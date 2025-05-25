using guvenport.Models.Interface;
using guvenport.Services;
using Microsoft.Extensions.DependencyInjection;

namespace guvenport.Services.IoC
{
    public static class ServiceContainer
    {

        public static void AddScopedService(this IServiceCollection services)
        {
            
  
            services.AddScoped<IAccidentService, AccidentService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IMedicalExaminationService, MedicalExaminationService>();
            services.AddScoped<IOfficeService, OfficeService>();
            services.AddScoped<IContractService, ContractService>();
            services.AddScoped<IWorkplaceService, WorkplaceService>();

            
        }
    }
}