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
        private readonly ApplicationDbContext data;
        private readonly IMapper mapper;
        private readonly IDealerService dealerService;


        public HouseController(ApplicationDbContext data, IMapper mapper, IDealerService dealerService)
        {
            this.mapper = mapper;
            this.data = data;
            this.dealerService = dealerService;
        }

        [HttpGet]
        public IActionResult Add()
        {

            string? userid = this.User.GetId();
            Dealer? dealer = this.dealerService.GetByUserId(userid);

            if (dealer == null)
            {
                TempData["Error"] = "First you should become a dealer.";
                return RedirectToAction("Index", "Home");
            }

            House house = new House();

            foreach (var cond in Enum.GetValues(typeof(Condition)))
            {
                house.Conditions.Add(cond.ToString());
            }

            house.DealerId = dealer.Id;

            return View(house);

        }
        [HttpPost]
        public IActionResult Add(House house)
        {
            var houseEntity = mapper.Map<House>(house);

            //byte[] photo = new byte[8000];
            //foreach (var item in Picture)
            //{
            //    if (item.Length > 0)
            //    {
            //        using (var stream = new MemoryStream())
            //        {
            //            item.CopyToAsync(stream);
            //            photo = stream.ToArray();
            //        }
            //    }
            //}

            //houseEntity.Picture = photo;

            // this.data.Houses.Add(houseEntity);
            // this.data.SaveChanges();

            return RedirectToAction("Add", "House");

        }
    }
}