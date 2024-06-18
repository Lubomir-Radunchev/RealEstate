using RealEstateProject.Database.Models;
using RealEstateProject.DtosModel.DealerDTO;

namespace RealEstateProject.Services
{
    public interface IDealerService
    {
        // nullable return 
        Dealer? GetByUserId(string userId);
        void Add(BecomeDealerDto dealerDto, string userId);
    }
}
