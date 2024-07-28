using RealEstateProject.Database.Models;

namespace RealEstateProject.DtosModel.HouseDto
{
    public class ForSellFormDto
    {
        public decimal PricePerQuadrature { get; set; }
        public House House { get; set; }
    }
}
