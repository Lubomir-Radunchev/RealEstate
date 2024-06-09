using RealEstateProject.Database;
using RealEstateProject.Database.Models;

namespace RealEstateProject.Services
{
    public class DealerService : IDealerService
    {
        private readonly ApplicationDbContext data;

        public DealerService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public Dealer? GetByUserId(string userId)
          => this.data.Dealers.FirstOrDefault(x => x.IdentityUserId == userId);
    }
}
