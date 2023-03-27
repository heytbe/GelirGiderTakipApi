using AutoMapper;
using Entity.API.Dto.Giderler;
using Entity.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.API.AutoMapper.GiderlerMap
{
    internal class GiderlerMapper : Profile
    {
        public GiderlerMapper() 
        {
            CreateMap<GiderlerAddDto, Giderler>().ReverseMap();
            CreateMap<GiderlerListDto, Giderler>().ReverseMap();
            CreateMap<GiderCategoryListDto, GiderCategory>().ReverseMap();
        }
    }
}
