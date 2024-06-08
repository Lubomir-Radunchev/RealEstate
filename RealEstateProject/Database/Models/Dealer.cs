using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace RealEstateProject.Database.Models
{
    public class Dealer
    {
        [Key]
        public int Id { get; set; }
        [Required, NotNull]
        public string Name{ get; set; }
        [Required, NotNull]
        public string PhoneNumber { get; set; }
        public decimal Devident { get; set; }
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
        public List<House> Houses = new List<House>();
    }
}
