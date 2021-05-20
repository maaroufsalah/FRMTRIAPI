using AutoMapper;
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

            //CreateMap<Ville, VilleDto>().ForMember(dest => dest.RegionName, opt => opt
            //                                  .MapFrom(src => src.Region.Name));
          
            #endregion Map

            #region Reverse map

            //CreateMap<VilleDto, Ville>();

            #endregion Reverse map
        }
    }
}
