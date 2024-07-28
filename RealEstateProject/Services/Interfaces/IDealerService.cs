using RealEstateProject.Database.Models;
using RealEstateProject.DtosModel.DealerDTO;

namespace RealEstateProject.Services.Interfaces
{
    public interface IDealerService
    {
        // nullable return 
        Dealer? GetByUserId(string userId);
         Task AddAsync(BecomeDealerDto dealerDto, string userId);
    }
}
