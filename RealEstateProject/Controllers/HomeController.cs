using Microsoft.AspNetCore.Authorization;
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
        private readonly ApplicationDbContext data;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext data)
        {
            this.data=data;
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
        //[HttpGet]
        //[Authorize]
        //public IActionResult BecomeDealer()
        //{

        //    return View();
        //}
        //[HttpPost]
        //public IActionResult BecomeDealer(DealerDto dealerDto)
        //{
        //    if (string.IsNullOrEmpty(dealerDto.PhoneNumber) || string.IsNullOrEmpty(dealerDto.Request))
        //    {
        //        return View();
        //    }

        //    DealerRequest dealer = new DealerRequest
        //    {
        //        Request = dealerDto.Request,
        //        PhoneNumber = dealerDto.PhoneNumber,
        //        Devident = dealerDto.Devident,
        //        IdentityUserId = this.User.GetId() //това е логнатия User  и го взима по id 
        //    };


        //    this.data.Add(dealer);
        //    this.data.SaveChanges();

        //    return RedirectToAction("Index","Home");
        //}
        [HttpGet]
        public IActionResult BecomeDealer() 
        {
            return View();
        }
        //[HttpPost]
        //public IActionResult BecomeDealer() 
        //{
        
        
        //}


    }
}
