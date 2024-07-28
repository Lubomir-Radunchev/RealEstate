using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RealEstateProject.Database;
using RealEstateProject.Database.Models;
using RealEstateProject.DtosModel.HouseDto;
using RealEstateProject.Services.Interfaces;

namespace RealEstateProject.Services
{
    public class PlaceForRentService : IPlaceForRentService
    {
        readonly IMapper mapper;
        private readonly ApplicationDbContext data;

        public PlaceForRentService(ApplicationDbContext data, IMapper mapper)
        {
            this.mapper = mapper;
            this.data = data;
        }

        public async Task AddAsync(House house)
        {
            var placeToRent = new PlaceToRent() { HouseId = house.Id, DepositePriceForMonth = (decimal)house.RentPrice * 2, PriceForMonth = (decimal)house.RentPrice };


            this.data.Add(placeToRent);
           await this.data.SaveChangesAsync();
        }

        public  List<ForRentFormDto>  GetAll()
        {
            // опитах да го направя Async но не успях 
            List<PlaceToRent> placeToRents = this.data.PlacesToRent.Include(h => h.House).ToList();
            List<ForRentFormDto> forRentDto = mapper.Map<List<ForRentFormDto>>(placeToRents);
            // mapper config 
             return forRentDto;
        }
    }
}
    