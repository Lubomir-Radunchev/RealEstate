using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RealEstateProject.Database;
using RealEstateProject.Database.Models;
using RealEstateProject.DtosModel.HouseDto;
using RealEstateProject.Extentions;
using RealEstateProject.Services;

namespace RealEstateProject.Controllers
{

    public class HouseController : BaseController
    {

        private readonly IMapper mapper;
        private readonly IHouseService houseService;
        private readonly IDealerService dealerService;


        public HouseController(IMapper mapper, IHouseService houseService, IDealerService dealerService)
        {
            this.mapper = mapper;
            this.houseService = houseService;
            this.dealerService = dealerService;
        }

        [HttpGet]
        public IActionResult Add()
        {
            var userId = User.GetId();
            var dealer = this.dealerService.GetByUserId(userId);

            if (dealer == null)
            {
                TempData["Error"] = "First you should become a dealer.";
                return RedirectToAction("Index", "Home");
            }


            House house = new House();

            foreach (var type in Enum.GetValues(typeof(UseType)))
            {
                house.Types.Add(type.ToString());
            }
            foreach (var cond in Enum.GetValues(typeof(Condition)))
            {
                house.Conditions.Add(cond.ToString());
            }

            //house.DealerId = dealer.Id;

            return View(house);
        }

        [HttpPost]
        public async Task<IActionResult> Add(House house)
        {
            var userId = User.GetId();
            var dealer = this.dealerService.GetByUserId(userId);

            if (dealer == null)
            {
                TempData["Error"] = "First you should become a dealer.";
                return RedirectToAction("Index", "Home");
            }

            house.DealerId = dealer.Id;


            try
            {
                await this.houseService.AddAsync(house);
            }
            catch (Exception e)
            {

                TempData["NotValidInputDealer"] = e.Message;
                return View();
            }


            return RedirectToAction("Add", "House");

        }
    }
}