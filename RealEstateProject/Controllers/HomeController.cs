﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstateProject.Database;
using RealEstateProject.Database.Models;
using RealEstateProject.DtosModel;
using RealEstateProject.Extentions;

namespace RealEstateProject.Controllers
{
    // [Authorize] -> validen

    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        

        public HomeController(ILogger<HomeController> logger )
        {
            
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
