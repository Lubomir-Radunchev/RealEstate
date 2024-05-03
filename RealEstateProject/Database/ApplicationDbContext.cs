using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RealEstateProject.Database.Models;

namespace RealEstateProject.Database
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);
        }
        public DbSet<PlaceToBuy> PlacesToBuy { get; set; }
        public DbSet<Dealer> Dealers { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<PlaceToRent> PlacesToRent { get; set; }
        public DbSet<DealerRequest> DealerRequests { get; set; }
    }
}
