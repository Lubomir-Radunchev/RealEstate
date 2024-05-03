using AutoMapper;
using RealEstateProject.DtosModel.DealerDTO;
using RealEstateProject.Migrations;

namespace RealEstateProject.Extentions
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<BecomeDealerDto,BecomeDealer>();
            this.CreateMap<BecomeDealer, BecomeDealerDto>();
            //this.CreateMap<DtoBuy, PlaceToBuy>();

            //this.CreateMap<DtoClient, Dealer>();

            //this.CreateMap<DtoRent, PlaceToRent>();
            //this.CreateMap<DtoHouse, House>();
            //this.CreateMap<PlaceToBuy, DtoBuy>();


            //this.CreateMap<PlaceToRent, DtoRent>();
            //this.CreateMap<House, DtoHouse>();
        }
    }
}

