using RealEstateProject.Database;
using RealEstateProject.Database.Models;

namespace RealEstateProject.Services
{
    public class PlaceForRentService : IPlaceForRentService
    {
        private readonly ApplicationDbContext data;

        public PlaceForRentService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public void Add(House house)
        {
            var placeToSell = new PlaceToRent() { HouseId = house.Id, DepositePriceForMonth = (decimal)house.RentPrice * 2, PriceForMonth = (decimal)house.RentPrice};


            this.data.Add(placeToSell);
            this.data.SaveChanges();
        }
    }
}
