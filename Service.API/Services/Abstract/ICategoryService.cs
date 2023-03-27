using Entity.API.Dto.Category;
using SharedLibrary.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.API.Services.Abstract
{
    public interface ICategoryService
    {
        Task<ResponseDto<CategoryListeOlusturDto>> AddAsync(CategoryDto categoryDto,string FileDir);
        Task<ResponseDto<List<CategoryListeOlusturDto>>> GetAllAsync();
        Task<ResponseDto<NoDataDto>> DeleteAsync(int id);
        Task<ResponseDto<CategoryListeOlusturDto>> GetByIdList(int id);
        Task<ResponseDto<CategoryListeOlusturDto>> CategoryAndImageUpdate(CategoryDto categoryDto,int id,string FileDir=null);
    }
}
