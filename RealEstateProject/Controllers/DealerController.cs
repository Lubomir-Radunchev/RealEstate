using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RealEstateProject.Database.Models;
using RealEstateProject.DtosModel.DealerDTO;
using RealEstateProject.Extentions;
using RealEstateProject.Services.Interfaces;

namespace RealEstateProject.Controllers
{
    public class DealerController : BaseController
    {
        private readonly IMapper mapper;
        private readonly IDealerService dealerService;
        // да се напрви сървизи за всички контролери !
        // и да се инплементират !
        public DealerController(IMapper mapper, IDealerService dealerService)
        {
            this.mapper = mapper;
            this.dealerService = dealerService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult BecomeDealer()
        {
            var userId = User.GetId();

            if (this.dealerService.GetByUserId(userId) != null)
            {
                TempData["Error"] = "You are already a dealer!";
                return RedirectToAction("Index", "Home");
            }

            if (userId == null)
            {
                TempData["Error"] = "First you should log in!";
                return RedirectToAction("Index", "Home");
            }
          
            BecomeDealerDto dto = new BecomeDealerDto();

            return View(dto);
        }
        [HttpPost]
        public IActionResult BecomeDealer(BecomeDealerDto dealerDto)
        {
            // validation
            if (string.IsNullOrEmpty(dealerDto.PhoneNumber) || string.IsNullOrEmpty(dealerDto.Name))
            {
                TempData["NotValidInputDealer"] = "Wrong input! Try again.";
                return View();
            }

            // състоянието на модела
            if (ModelState.IsValid != true)
            {
                TempData["NotValidInputDealer"] = "Wrong input! Try again.";
                return View();
            }

            // adding 
            // ClaimPrincipalExtention
            try
            {
                this.dealerService.Add(dealerDto, this.User.GetId());
            }
            catch (Exception e)
            {
                TempData["NotValidInputDealer"] = e.Message;
                return View();
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
