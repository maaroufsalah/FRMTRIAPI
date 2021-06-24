using Application.Models.DTOs.Region;
using Application.Models.DTOs.Ville;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            #region Map

            CreateMap<Ville, VilleForListDto>().ForMember(dest => dest.NomRegion, opt => opt
                                              .MapFrom(src => src.Region.NomRegion));
            CreateMap<Ville, VilleForDetailDto>().ForMember(dest => dest.NomRegion, opt => opt
                                  .MapFrom(src => src.Region.NomRegion));

            CreateMap<Region, RegionForListDto>().ReverseMap();
            CreateMap<Region, RegionForDetailDto>().ReverseMap();
            #endregion Map

            #region Reverse map

            CreateMap<VilleForListDto, Ville>();
            CreateMap<VilleForDetailDto, Ville>();

            #endregion Reverse map
        }
    }
}
