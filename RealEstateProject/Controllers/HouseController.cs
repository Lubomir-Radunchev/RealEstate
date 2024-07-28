using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RealEstateProject.Database;
using RealEstateProject.Database.Models;
using RealEstateProject.Database.Models.Enums;
using RealEstateProject.DtosModel.HouseDto;
using RealEstateProject.Extentions;
using RealEstateProject.Services.Interfaces;

namespace RealEstateProject.Controllers
{

    public class HouseController : BaseController
    {

        private readonly IMapper mapper;
        private readonly IHouseService houseService;
        private readonly IDealerService dealerService;
        private readonly IPlaceForRentService placeForRent;
        private readonly IPlaceForSellService placeForSell;
        private readonly ApplicationDbContext data;


        public HouseController(IMapper mapper, IHouseService houseService, IDealerService dealerService, IPlaceForRentService placeForRent, IPlaceForSellService placeForSell, ApplicationDbContext data)
        {
            this.mapper = mapper;

            this.houseService = houseService;
            this.dealerService = dealerService;
            this.placeForRent = placeForRent;
            this.placeForSell = placeForSell;
            this.data = data;
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

            var house = new HouseFormDto();

            FillDropdowns(house);
            //house.DealerId = dealer.Id;

            return View(house);
        }

        [HttpPost]
        public async Task<IActionResult> Add(HouseFormDto houseDto)
        {
            string? userId = string.Empty;
            try
            {
                userId = CheckLoggedUser();
            }
            catch (Exception)
            {
                TempData["Error"] = "First you should login first.";
                return RedirectToAction("Index", "Home");
            }
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
                    CheckUsetype(houseDto, house);
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

        [HttpGet]
        public IActionResult All()
        {
            List<House> houses = this.data.Houses.ToList();

            return View(houses);
        }

        [HttpGet]
        public IActionResult GetForRent()
        {
            List<ForRentFormDto> placesToRent = this.placeForRent.GetAll();
            return View(placesToRent);
        }

        [HttpGet]
        public IActionResult GetForSale()
        {
            var placesToSell = this.placeForSell.GetAll();
            return View(placesToSell);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            this.houseService.Delete(id);
            return RedirectToAction("All");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = this.data.Houses.FirstOrDefault(x => x.Id == id);
            var house = mapper.Map<HouseFormDto>(model);

            FillDropdowns(house);

            return View(house);
        }

        [HttpPost]
        public IActionResult Edit(HouseFormDto houseDto)
        {
            this.houseService.EditAsync(houseDto);

            return RedirectToAction("All");
        }

        private static void FillDropdowns(HouseFormDto house)
        {
            foreach (var type in Enum.GetValues(typeof(UseType)))
            {
                house.Types.Add(type.ToString());
            }
            foreach (var cond in Enum.GetValues(typeof(Condition)))
            {
                house.Conditions.Add(cond.ToString());
            }
        }

        private void CheckUsetype(HouseFormDto houseDto, House house)
        {
            if (houseDto.UseType == UseType.Both)
            {
                this.placeForRent.Add(house);
                this.placeForSell.Add(house);
            }
            if (houseDto.UseType == UseType.For_Sell)
            {
                this.placeForSell.Add(house);
            }
            if (houseDto.UseType == UseType.For_Rent)
            {
                this.placeForRent.Add(house);
            }
        }

        private string? CheckLoggedUser()
        {
            var userId = User.GetId();
            if (userId == null)
            {
                throw new Exception();
            }

            return userId;
        }

    }
}