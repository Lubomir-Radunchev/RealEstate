using RealEstateProject.Database.Models;
using RealEstateProject.DtosModel.HouseDto;

namespace RealEstateProject.Services
{
    public interface IHouseService
    {
        Task<int> AddAsync(House houseDto);

    }
}
