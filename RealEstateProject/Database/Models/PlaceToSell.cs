using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace RealEstateProject.Database.Models
{
    public class PlaceToSell
    {
        [Key]
        public int Id { get; set; }
        [Required, NotNull]
        public decimal PricePerQuadrature { get; set; }
        public int HouseId { get; set; }
        public House House { get; set; }
    }
}
