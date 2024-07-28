using AutoMapper;
using RealEstateProject.Database;
using RealEstateProject.Database.Models;
using RealEstateProject.DtosModel.HouseDto;
using RealEstateProject.Services.Interfaces;

namespace RealEstateProject.Services
{
    public class HouseService(ApplicationDbContext data, IMapper mapper, DealerService dealerService) : IHouseService
    {
        private readonly IMapper mapper = mapper;
        private readonly ApplicationDbContext data = data;
        private readonly DealerService _dealerService = dealerService;

        public async Task<int> AddAsync(House houseDto)
        {
            if (houseDto == null
                         || String.IsNullOrEmpty(houseDto.City)
                         || String.IsNullOrEmpty(houseDto.Picture)
                         || String.IsNullOrEmpty(houseDto.Street)
                         || houseDto.DealerId < 0
                         || houseDto.Quadrature < 0
                   )
            {
                throw new ArgumentException("Wrong data");
            }

            await this.data.AddAsync(houseDto);
            await this.data.SaveChangesAsync();

            return houseDto.Id;
        }


        public async Task EditAsync(HouseFormDto houseDto)
        {
            if (houseDto == null
                  || String.IsNullOrEmpty(houseDto.City)
                  || String.IsNullOrEmpty(houseDto.Picture)
                  || String.IsNullOrEmpty(houseDto.Street)
                  || houseDto.DealerId < 0
                  || houseDto.Quadrature < 0
            )
            {
                throw new ArgumentException("Wrong data");
            }
            var dealerId = GetDealerIdByHouseId(houseDto.Id);//  за да вземем id на dealer! 

            var house = this.mapper.Map<House>(houseDto); //използваме auto mapper за да ни setne всички пропъртита автоматичнно! 
            house.DealerId = dealerId; //за да ни setne  id на dealer!

            this.data.Houses.Update(house);
            await this.data.SaveChangesAsync();
        }

        public async Task<House?> GetByIdAsync(int id) => await this.data.Houses.FindAsync(id);

        public async Task DeleteAsync(int id, string userId)
        {
            //var UserId = this.data.Dealer.Id;

            var dealer = this._dealerService.GetByUserId(userId);
            var house = await GetByIdAsync(id);

            if (dealer == null) { }

            if (dealer.Id == house.DealerId) { }


            this.data.Houses.Remove(house);
            await this.data.SaveChangesAsync();
        }

        public int GetDealerIdByHouseId(int id) => this.data.Houses.Where(x => x.Id == id).Select(d => d.DealerId).FirstOrDefault();
    }
}