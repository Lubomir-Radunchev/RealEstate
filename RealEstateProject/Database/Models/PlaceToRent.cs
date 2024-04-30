using System.ComponentModel.DataAnnotations;

namespace RealEstateProject.Database.Models
{
    public class PlaceToRent
    {
        [Key]
        public int Id { get; set; }
        public decimal PriceForMonth { get; set; }
        public decimal DepositePriceForMonth { get; set; }
        public int HouseId { get; set; }
        public House House { get; set; }
    }
}
