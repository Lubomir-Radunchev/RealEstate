using RealEstateProject.Database.Models;
using RealEstateProject.DtosModel.HouseDto;

namespace RealEstateProject.Services.Interfaces
{
    public interface IPlaceForRentService
    {
        Task AddAsync(House house);
        Task<List<ForRentFormDto>> GetAllAsync();
    }
}
