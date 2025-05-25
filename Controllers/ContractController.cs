using guvenport.Models.Interface;
using Microsoft.AspNetCore.Mvc;

namespace guvenport.Controllers
{
    [Route("Contract")]
    public class ContractController : Controller
    {
        private readonly IContractService _contractService;

        public ContractController(IContractService contractService)
        {
            _contractService = contractService;
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
