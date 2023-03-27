using Entity.API.Dto.Giderler;
using SharedLibrary.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.API.Services.Abstract
{
    public interface IGiderlerService
    {
        Task<ResponseDto<List<GiderlerListDto>>> GetAll();
        Task<ResponseDto<GiderlerListDto>> AddGiderlerAsync(GiderlerAddDto giderlerAddDto, string filedir);
    }
}
