using RealEstateProject.Database.Models;
using RealEstateProject.DtosModel.HouseDto;

namespace RealEstateProject.Services.Interfaces
{
    public interface IHouseService
    {
        int GetDealerIdByHouseId(int id);
        Task DeleteAsync(int id, string userId);
        Task EditAsync(HouseFormDto houseDto);
        Task<int> AddAsync(House houseDto);
        Task<House?> GetByIdAsync(int id); // nullable
        Task<List<HouseFormDto>> GetAllAsync();

    }
}
