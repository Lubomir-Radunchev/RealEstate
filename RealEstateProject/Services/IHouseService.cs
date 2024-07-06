using RealEstateProject.Database.Models;
using RealEstateProject.DtosModel.HouseDto;

namespace RealEstateProject.Services
{
    public interface IHouseService
    {
        Task AddAsync(House houseDto);
    }
}
