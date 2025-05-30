﻿using guvenport.Models.Interface;
using Microsoft.AspNetCore.Mvc;

namespace guvenport.Controllers
{
    [Route("Workplace")]
    public class WorkplaceController : Controller
    {
        private readonly IWorkplaceService _WorkplaceService;

        public WorkplaceController(IWorkplaceService WorkplaceService)
        {
            _WorkplaceService = WorkplaceService;
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
