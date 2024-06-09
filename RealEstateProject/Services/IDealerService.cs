using RealEstateProject.Database.Models;

namespace RealEstateProject.Services
{
    public interface IDealerService
    {
        // nullable return 
        Dealer? GetByUserId(string userId);
    }
}
