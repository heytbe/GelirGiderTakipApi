using AutoMapper;
using Entity.API.Dto.Category;
using Entity.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.API.AutoMapper.CategoryMap
{
    public class CategoryMapper:Profile
    {
        public CategoryMapper() 
        {
            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<CategoryListeOlusturDto, Category>().ReverseMap();
        }
    }
}
