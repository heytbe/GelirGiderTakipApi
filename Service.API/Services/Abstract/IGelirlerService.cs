using Entity.API.Dto.Gelirler;
using SharedLibrary.Dto;

namespace Service.API.Services.Abstract
{
    public interface IGelirlerService
    {
        Task<ResponseDto<List<GelirlerListeDto>>> GetAllAsync(); 
        Task<ResponseDto<GelirlerListeDto>> GelirCategoryImageAddAsync(GelirlerDto gelirlerDto,string fileDir = null);
        Task<ResponseDto<NoDataDto>> UpdateGelirlerCategory(GelirlerUpdateDto gelirlerDto, int id);
        Task<ResponseDto<NoDataDto>> DeleteGelir(int id);
        Task<ResponseDto<NoDataDto>> UpdateImageGelirlerImages(GelirImageUpdateDto gelirImageUpdateDto, int gelirid, int imageid, string fileDir);
    }
}
