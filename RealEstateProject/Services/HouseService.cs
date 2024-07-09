using RealEstateProject.Database;
using RealEstateProject.Database.Models;
using RealEstateProject.DtosModel.HouseDto;

namespace RealEstateProject.Services
{
    public class HouseService : IHouseService
    {
        private readonly ApplicationDbContext data;

        public HouseService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public async Task<int> AddAsync(House houseDto)
        {
            if (houseDto == null
    || String.IsNullOrEmpty(houseDto.City)
    || String.IsNullOrEmpty(houseDto.Picture)
    || String.IsNullOrEmpty(houseDto.Street)
    || houseDto.DealerId < 0
    || houseDto.Quadrature < 0)
            {
                throw new ArgumentException("Wrong data");
            }



            await this.data.AddAsync(houseDto);
            await this.data.SaveChangesAsync();


            return houseDto.Id;

        }
    }
}