using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RealEstateProject.Database;

namespace RealEstateProject.Controllers
{
    public class DealerController : Controller
    {
        private readonly ApplicationDbContext data;
        private readonly IMapper mapper;



        public DealerController(ApplicationDbContext data, IMapper mapper)
        {
            this.mapper = mapper;
            this.data = data;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
