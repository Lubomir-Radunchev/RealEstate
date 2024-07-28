using RealEstateProject.Database.Models;
using RealEstateProject.DtosModel.HouseDto;

namespace RealEstateProject.Services.Interfaces
{
    public interface IPlaceForSellService
    {
        Task AddAsync(House house);
        List<ForSellFormDto> GetAll();
    }
}
