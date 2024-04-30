using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RealEstateProject.Database;

namespace RealEstateProject.Controllers
{
    public class HouseController : Controller
    {
        private readonly ApplicationDbContext data;
        private readonly IMapper mapper;



        public HouseController(ApplicationDbContext data, IMapper mapper)
        {
            this.mapper = mapper;
            this.data = data;
        }
        //[HttpGet]
        //public IActionResult AddHouse()
        //{
        //    DtoHouse house = new DtoHouse();

        //    foreach (var cond in Enum.GetValues(typeof(Condition)))
        //    {
        //        house.Conditions.Add(cond.ToString());
        //    }

        //    return View(house);

        //}
        //[HttpPost]
        //public IActionResult AddHouse(DtoHouse house,List<IFormFile> Picture) 
        //{
        //    if (house.Id <= 0)
        //    {
        //        // message: try again 
        //        TempData["error"] = "Try Again";


        //        foreach (var cond in Enum.GetValues(typeof(Condition)))
        //        {
        //            house.Conditions.Add(cond.ToString());
        //        }

        //        return View();
        //    }
        //    var houseEntity = mapper.Map<House>(house);

        //    byte[] photo = new byte[8000];
        //    foreach (var item in Picture)
        //    {
        //        if (item.Length > 0)
        //        {
        //            using (var stream = new MemoryStream())
        //            {
        //                item.CopyToAsync(stream);
        //                photo = stream.ToArray();
        //            }
        //        }
        //    }

        //    houseEntity.Picture = photo;

        //    this.data.Houses.Add(houseEntity);
        //    this.data.SaveChanges();

        //    return RedirectToAction("Add", "House");

    }
    }
