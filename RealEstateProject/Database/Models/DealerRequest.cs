using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace RealEstateProject.Database.Models
{
    public class DealerRequest
    {
        [Key]
        public int Id { get; set; }
        [Required,NotNull]
        public string Request { get; set; }
        [Required, NotNull]
        public string PhoneNumber { get; set; }
        [Required, NotNull]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
    }
}
