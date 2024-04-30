using Microsoft.AspNetCore.Mvc;
using RealEstateProject.DtosModel;

namespace RealEstateProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
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
        [HttpGet]
        public IActionResult BecomeDealer()
        {

            return View();
        }
        [HttpPost]
        public IActionResult BecomeDealer(DealerDto dealerDto ) 
        {
        return View();
        
        }
    }
}
