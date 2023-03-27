using AutoMapper;
using Entity.API.Dto.Images;
using Entity.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.API.AutoMapper.ImageMap
{
    public class ImageMapper:Profile
    {
        public ImageMapper() 
        {
            CreateMap<ImagesDto, Images>().ReverseMap();
        }
    }
}
