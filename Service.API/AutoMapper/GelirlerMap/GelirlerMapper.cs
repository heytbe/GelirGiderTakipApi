using AutoMapper;
using Entity.API.Dto.Gelirler;
using Entity.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.API.AutoMapper.GelirlerMap
{
    public class GelirlerMapper:Profile
    {
        public GelirlerMapper()
        {
            CreateMap<GelirlerDto, Gelirler>().ReverseMap();
            CreateMap<GelirlerListeDto, Gelirler>().ReverseMap();
            CreateMap<GelirCategoryListDto,GelirCategory>().ReverseMap();
            CreateMap<GelirlerUpdateDto, Gelirler>().ReverseMap();
        }
    }
}
