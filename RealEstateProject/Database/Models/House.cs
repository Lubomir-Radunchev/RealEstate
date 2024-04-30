using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace RealEstateProject.Database.Models
{
    public class House
    {
        [Key]
        public int Id { get; set; }
        [Required, NotNull]
        public string Street { get; set; }
        [Required, NotNull]
        public string City { get; set; }
        [Required, NotNull]
        public int Quadrature { get; set; }
        public byte[] Picture { get; set; }
        [Required, NotNull]
        public string Description { get; set; }
        public int DealerId { get; set; }
        public Dealer Dealer { get; set; }
        public Condition Condition { get; set; }
    }
    public enum Condition
    {
        Good, Bad
    }
}
