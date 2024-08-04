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
        public async Task<IActionResult> AddAsync()
        {
            var userId = User.GetId();
            var dealer = await this.dealerService.GetByUserIdAsync(userId);

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
            var dealer = await this.dealerService.GetByUserIdAsync(userId);

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
        public async Task<IActionResult> AllAsync()
        {
            List<HouseFormDto> houses = await this.houseService.GetAllAsync();

            return View(houses);
        }

        [HttpGet]
        public async Task<IActionResult> GetForRent()
        {
            List<ForRentFormDto> placesToRent = await this.placeForRent.GetAllAsync();
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
        public async Task<IActionResult> Delete(int id)
        {
            var userId = User.GetId();
            await this.houseService.DeleteAsync(id, userId);
            return RedirectToAction("All");
        }

        [HttpGet]
        public async Task<IActionResult> EditAsync(int id)
        {
            // ??????????????? // var model = this.data.Houses.FirstOrDefault(x => x.Id == id);
            var model = await this.houseService.GetByIdAsync(id);
            var house = mapper.Map<HouseFormDto>(model);

            FillDropdowns(house);

            return View(house);
        }

        [HttpPost]
        public async Task<IActionResult> EditAsync(HouseFormDto houseDto)
        {
            await this.houseService.EditAsync(houseDto);

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

        private async void CheckUsetype(HouseFormDto houseDto, House house)
        {
            if (houseDto.UseType == UseType.Both)
            {
                await this.placeForRent.AddAsync(house);
                await this.placeForSell.AddAsync(house);
            }
            if (houseDto.UseType == UseType.For_Sell)
            {
                await this.placeForSell.AddAsync(house);
            }
            if (houseDto.UseType == UseType.For_Rent)
            {
                await this.placeForRent.AddAsync(house);
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