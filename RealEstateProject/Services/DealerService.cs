using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RealEstateProject.Database;
using RealEstateProject.Database.Models;
using RealEstateProject.DtosModel.DealerDTO;
using RealEstateProject.Services.Interfaces;

namespace RealEstateProject.Services
{
    public class DealerService : IDealerService
    {
        private readonly ApplicationDbContext data;
        private readonly IMapper mapper;

        public DealerService(ApplicationDbContext data, IMapper mapper)
        {
            this.mapper = mapper;
            this.data = data;
        }

        public async Task AddAsync(BecomeDealerDto dealerDto, string userId)
        {
            if (userId == null)
            {
                throw new ArgumentNullException("User is not found ");
            }


            if (GetByUserIdAsync(userId) != null)
            {
                throw new ArgumentNullException("User is not found ");
            }
            if (dealerDto.Devident <= 0 || dealerDto.Devident > 20)
            {
                throw new ArgumentNullException("Wrong value for devident");
            }

            await this.data.AddAsync(dealerDto);
            await this.data.SaveChangesAsync();

            var becomeDealerEntity = mapper.Map<Dealer>(dealerDto);
            becomeDealerEntity.IdentityUserId = userId;
        }

        public async Task<Dealer?> GetByUserIdAsync(string userId)
          => await this.data.Dealers.FirstOrDefaultAsync(x => x.IdentityUserId == userId);
    }
}
