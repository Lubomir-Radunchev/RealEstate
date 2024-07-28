using RealEstateProject.Database.Models;

namespace RealEstateProject.DtosModel.HouseDto
{
    public class ForRentFormDto 
    {
        public decimal PriceForMonth { get; set; }
        public decimal DepositePriceForMonth { get; set; }
        public House House { get; set; }
    }
}
