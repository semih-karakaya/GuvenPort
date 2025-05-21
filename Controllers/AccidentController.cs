using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using guvenport.Models; // Modellerin namespace'ini ekle
using guvenport.Services;
using guvenport.Models.Interface; // Servisinin namespace'ini ekle

namespace guvenport.Controllers
{
    [Route("accident")]
    public class AccidentController : Controller
    {
        private readonly IAccidentService _accidentService; // Change type to IAccidentService

        public AccidentController(IAccidentService accidentService)
        {
            _accidentService = accidentService; // No change needed here
        }

        [HttpGet("list")]
        public IActionResult List()
        {
            return View("List");
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreatePost()
        {
            var accDate = Request.Form["AccDate"];
            var accTime = Request.Form["AccTime"];
            var fatality = Request.Form["Fatality"] == "on";
            var injury = Request.Form["Injury"] == "on";
            var propertyDamage = Request.Form["PropertyDamage"] == "on";
            var nearMiss = Request.Form["NearMiss"] == "on";
            var storyOfAccident = Request.Form["StoryOfAccident"];
            var idWorkplace = int.TryParse(Request.Form["IdWorkplace"], out var idWp) ? idWp : (int?)null;
            var sgkInfoDate = Request.Form["SgkInfoDate"];
            var sgkInfoCheck = Request.Form["SgkInfoCheck"] == "on";

            var accident = new AccidentDto
            {
                AccDate = string.IsNullOrEmpty(accDate) ? null : DateOnly.Parse(accDate),
                AccTime = string.IsNullOrEmpty(accTime) ? null : TimeOnly.Parse(accTime),
                Fatality = fatality,
                Injury = injury,
                PropertyDamage = propertyDamage,
                NearMiss = nearMiss,
                StoryOfAccident = storyOfAccident,
                IdWorkplace = idWorkplace,
                SgkInfoDate = string.IsNullOrEmpty(sgkInfoDate) ? null : DateOnly.Parse(sgkInfoDate),
                SgkInfoCheck = sgkInfoCheck
            };

            await _accidentService.AddAccidentAsync(accident);
            return RedirectToAction("List");
        }
    }
}
