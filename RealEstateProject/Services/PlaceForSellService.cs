using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RealEstateProject.Database;
using RealEstateProject.Database.Models;
using RealEstateProject.DtosModel.HouseDto;
using RealEstateProject.Services.Interfaces;

namespace RealEstateProject.Services
{
    public class PlaceForSellService : IPlaceForSellService
    {
        private readonly IMapper mapper;
        private readonly ApplicationDbContext data;

        public PlaceForSellService(ApplicationDbContext data, IMapper mapper)
        {
            this.mapper = mapper;
            this.data = data;
        }

        public async Task AddAsync(House house)
        {
            var placeToSell = new PlaceToSell() { HouseId = house.Id, PricePerQuadrature = house.Price / house.Quadrature };

            this.data.Add(placeToSell);
            await this.data.SaveChangesAsync();
        }

        public List<ForSellFormDto> GetAll()
        {

            var placesToSell = this.data.PlacesToSell.Include(h => h.House).ToList();
            var forSellDtos = mapper.Map<List<ForSellFormDto>>(placesToSell);


            return forSellDtos;
        }
    }
}
