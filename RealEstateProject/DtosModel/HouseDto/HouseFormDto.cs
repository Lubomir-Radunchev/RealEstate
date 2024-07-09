using RealEstateProject.Database.Models;
using RealEstateProject.Database.Models.Enums;
using System.Diagnostics.CodeAnalysis;

namespace RealEstateProject.DtosModel.HouseDto
{
    public class HouseFormDto
    {
        public string Street { get; set; }

        public string City { get; set; }

        public decimal Price { get; set; }

        public decimal? RentPrice { get; set; }


        public int Quadrature { get; set; }
        public string Picture { get; set; }

        public string Description { get; set; }
        public int DealerId { get; set; }
        public Dealer Dealer { get; set; }
        public Condition Condition { get; set; }

        public List<string> Conditions = new List<string>();
        public UseType UseType { get; set; }
        public List<string> Types = new List<string>();
    }

}