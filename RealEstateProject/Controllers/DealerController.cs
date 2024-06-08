using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RealEstateProject.Database;
using RealEstateProject.Database.Models;
using RealEstateProject.DtosModel.DealerDTO;
using RealEstateProject.Extentions;

namespace RealEstateProject.Controllers
{
    public class DealerController : BaseController
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
        [HttpGet]
        public IActionResult BecomeDealer()
        {
            BecomeDealerDto dto = new BecomeDealerDto();

            return View(dto);
        }
        [HttpPost]
        public IActionResult BecomeDealer(BecomeDealerDto dealerDto)
        {
            // validation
            if (string.IsNullOrEmpty(dealerDto.PhoneNumber) || dealerDto.Devident > 20 || dealerDto.Devident < 0 || string.IsNullOrEmpty(dealerDto.Name))
            {
                TempData["NotValidInputDealer"] = "Wrong input! Try again.";
                return View();
            }

            if (ModelState.IsValid != true)
            {
                TempData["NotValidInputDealer"] = "Wrong input! Try again.";
                return View();
            }

            // adding 
            // ClaimPrincipalExtention
            var becomeDealerEntity = mapper.Map<Dealer>(dealerDto);
            var userId = User.GetId();
            becomeDealerEntity.IdentityUserId = userId;

            this.data.Add(becomeDealerEntity);
            this.data.SaveChanges();


          return  RedirectToAction("Index","Home");
        }
    }
}
