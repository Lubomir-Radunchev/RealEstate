using AutoMapper;
using RealEstateProject.Database.Models;
using RealEstateProject.DtosModel.DealerDTO;
using RealEstateProject.DtosModel.HouseDto;
using RealEstateProject.Migrations;

namespace RealEstateProject.Extentions
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<House, HouseFormDto>();
            this.CreateMap<HouseFormDto, House>();
           this.CreateMap<BecomeDealerDto,Dealer>();
            this.CreateMap<Dealer, BecomeDealerDto>();
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

