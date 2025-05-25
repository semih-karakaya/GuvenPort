namespace guvenport.Models.Interface
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using guvenport.Models;

    public interface IAccidentService
    {
        Task<IEnumerable<AccidentDto>> ListAccidentsAsync();
        Task AddAccidentAsync(AccidentDto accident);
    }
    public interface IEmployeeService 
    { 
    }
    public interface IMedicalExaminationService
    {
    }
    public interface IContractService
    {
    }
    public interface IWorkplaceService
    {
    }
    public interface IOfficeService
    {
        Task<List<OfficeDto>> ListOfficesAsync();
       
    }
}
