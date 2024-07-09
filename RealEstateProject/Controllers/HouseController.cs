using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RealEstateProject.Database;
using RealEstateProject.Database.Models;
using RealEstateProject.Database.Models.Enums;
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
        private readonly IPlaceForRentService placeForRent;
        private readonly IPlaceForSellService placeForSell;


        public HouseController(IMapper mapper, IHouseService houseService, IDealerService dealerService, IPlaceForRentService placeForRent, IPlaceForSellService placeForSell)
        {
            this.mapper = mapper;
            this.houseService = houseService;
            this.dealerService = dealerService;
            this.placeForRent = placeForRent;
            this.placeForSell = placeForSell;
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


            HouseFormDto house = new HouseFormDto();

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
        public async Task<IActionResult> Add(HouseFormDto houseDto)
        {
            var userId = User.GetId();
            var dealer = this.dealerService.GetByUserId(userId);

            if (dealer == null)
            {
                TempData["Error"] = "First you should become a dealer.";
                return RedirectToAction("Index", "Home");
            }

            houseDto.DealerId = dealer.Id;

            var house = mapper.Map<House>(houseDto);

            try
            {
                int id = await this.houseService.AddAsync(house);

                if (id != 0)
                {

                    if (houseDto.UseType == UseType.Both)
                    {
                        this.placeForRent.Add(house);
                        this.placeForSell.Add(house);
                    }
                }
            }
            catch (Exception e)
            {

                TempData["NotValidInputDealer"] = e.Message;
                return View();
            }

            TempData["SuccsessMessage"] = "You have added you house!";


            // TODO: REDIRECT TO ALL HOUSES
            return RedirectToAction("Add", "House");

        }
    }
}