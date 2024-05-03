using System.ComponentModel.DataAnnotations;

namespace RealEstateProject.DtosModel.DealerDTO
{
    public class BecomeDealerDto
    {
        [StringLength(10)]
        public string PhoneNumber { get; set; }

        [Range(0, 20)]
        public decimal Devident { get; set; }
    }
}
