using RealEstateProject.Database.Models;
using System.Diagnostics.CodeAnalysis;

namespace RealEstateProject.DtosModel.HouseDto
{
    public class HouseFormDto
    {
       
        public string Street { get; set; }
      
        public string City { get; set; }
       
        public int Quadrature { get; set; }
        public Condition Condition { get; set; }
        public byte[] Picture { get; set; }
    }
}
