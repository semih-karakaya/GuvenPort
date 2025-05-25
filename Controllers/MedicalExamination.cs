using guvenport.Models.Interface;
using Microsoft.AspNetCore.Mvc;

namespace guvenport.Controllers
{
    [Route("medex")]
    public class MedicalExamination : Controller
    {
        private readonly IMedicalExaminationService _medicalExaminationService;
        public MedicalExamination(IMedicalExaminationService medicalExaminationService)
        {
            _medicalExaminationService = medicalExaminationService;
        }
        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpGet("list")]
        public IActionResult list()
        {
            return View();
        }
        [HttpGet("litelist")]
        public IActionResult litelist()
        {
            return View();
        }
    }
}
