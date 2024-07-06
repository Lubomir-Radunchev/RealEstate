using Microsoft.AspNetCore.Mvc;

namespace RealEstateProject.Controllers
{
    public class OffertsController : BaseController
    {
        public IActionResult Index()
        {
            return View();

        }
    }
}
