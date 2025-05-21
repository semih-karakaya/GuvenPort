using guvenport.Models.Interface;
using Microsoft.AspNetCore.Mvc;

namespace guvenport.Controllers
{
    [Route("employee")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet("create")]
        public IActionResult Create()
        {
            return View("create");
        }
        [HttpGet("list")]
        public IActionResult list()
        {
            return View("list");
        }
    }
}
