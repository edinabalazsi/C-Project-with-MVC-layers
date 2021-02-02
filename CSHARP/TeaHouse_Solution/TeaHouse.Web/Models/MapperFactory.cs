using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeaHouse.Web.Models
{
    public class MapperFactory
    {
        public static IMapper CreateMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TeaHouse.Data.EXTRA, TeaHouse.Web.Models.Extra>().
                    ForMember(dest => dest.Id, map => map.MapFrom(src => src.EXT_ID)).
                    ForMember(dest => dest.ExtraName, map => map.MapFrom(src => src.ENAME)).
                    ForMember(dest => dest.Category, map => map.MapFrom(src => src.CATEGORY)).
                    ForMember(dest => dest.Allergen, map => map.MapFrom(src => src.ALLERGEN)).
                    ForMember(dest => dest.Available, map => map.MapFrom(src => src.AVAILABLE)).
                    ForMember(dest => dest.Price, map => map.MapFrom(src => src.PRICE));
            });
            return config.CreateMapper();
        }
    }
}