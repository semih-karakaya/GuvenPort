using guvenport.Models.Interface;
using Microsoft.AspNetCore.Mvc;

namespace guvenport.Controllers
{
    [Route("Office")]
    public class OfficeController : Controller
    {
        private readonly IOfficeService _officeService;

        public OfficeController(IOfficeService officeService)
        {
            _officeService = officeService;
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet("list")]
        public IActionResult List()
        {
            return View();
        }
    }
}
