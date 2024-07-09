using RealEstateProject.Database;
using RealEstateProject.Database.Models;

namespace RealEstateProject.Services
{
    public class PlaceForSellService : IPlaceForSellService
    {
        private readonly ApplicationDbContext data;

        public PlaceForSellService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public void Add(House house)
        {
            var placeToSell = new PlaceToSell() { HouseId = house.Id, PricePerQuadrature = house.Price / house.Quadrature };


            this.data.Add(placeToSell);
            this.data.SaveChanges();
        }
    }
}
