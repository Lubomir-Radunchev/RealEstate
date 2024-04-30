using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RealEstateProject.Database;


namespace RealEstateProject.Controllers
{
    public class ClientController : Controller
    {
        private readonly ApplicationDbContext data;
        private readonly IMapper mapper;



        public ClientController(ApplicationDbContext data, IMapper mapper)
        {
            this.mapper = mapper;
            this.data = data;
        }
       
    }
}
