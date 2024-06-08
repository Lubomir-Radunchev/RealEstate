using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstateProject.Database;
using RealEstateProject.Database.Models;
using RealEstateProject.DtosModel.HouseDto;
using RealEstateProject.Extentions;

namespace RealEstateProject.Controllers
{

    public class HouseController : BaseController
    {
        private readonly ApplicationDbContext data;
        private readonly IMapper mapper;



        public HouseController(ApplicationDbContext data, IMapper mapper)
        {
            this.mapper = mapper;
            this.data = data;
        }
        [HttpGet]
        public IActionResult Add()
        {
            var userid = this.User.GetId();

            var dealer = this.data.Dealers.Where(x => x.IdentityUserId == userid).FirstOrDefault();

            if (dealer == null)
            {
                return RedirectToAction("Dealer", "BecomeDealer");            }

            House house = new House();

            foreach (var cond in Enum.GetValues(typeof(Condition)))
            {
                house.Conditions.Add(cond.ToString());
            }

            return View(house);

        }
        [HttpPost]
        public IActionResult Add(HouseFormDto house, List<IFormFile> Picture)
        {
            var houseEntity = mapper.Map<House>(house);

            byte[] photo = new byte[8000];
            foreach (var item in Picture)
            {
                if (item.Length > 0)
                {
                    using (var stream = new MemoryStream())
                    {
                        item.CopyToAsync(stream);
                        photo = stream.ToArray();
                    }
                }
            }

            houseEntity.Picture = photo;

            this.data.Houses.Add(houseEntity);
            this.data.SaveChanges();

            return RedirectToAction("House", "Add");

        }
    }
}