using AutoMapper;
using Data.API.Dal.EfGiderlerDal.Abstract;
using Data.API.UnitOfWork.Abstract;
using Entity.API.Dto.Giderler;
using Service.API.Services.Abstract;
using SharedLibrary.Dto;

namespace Service.API.Services.Cocrate
{
    public class GiderlerService : IGiderlerService
    {
        private readonly IGiderlerDal _giderlerDal;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GiderlerService(IGiderlerDal giderlerDal, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _giderlerDal = giderlerDal;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseDto<List<GiderlerListDto>>> GetAll()
        {
            var giderler = await _giderlerDal.GetAllAsync(x => x.IsDeleted == false,x => x.Categories,x => x.Images);
            var automapper = _mapper.Map<List<GiderlerListDto>>(giderler);
            return ResponseDto<List<GiderlerListDto>>.Success(automapper, 200);
        }

        public async Task<ResponseDto<GiderlerListDto>> AddGiderlerAsync(GiderlerAddDto giderlerAddDto, string filedir)
        {
            var giderEkle = await _giderlerDal.AddGiderlerAsync(giderlerAddDto, filedir);
            await _giderlerDal.AddAsync(giderEkle);
            await _unitOfWork.SaveAsync();
            var automapper = _mapper.Map<GiderlerListDto>(giderEkle);
            return ResponseDto<GiderlerListDto>.Success(automapper,200);
        }
    }
}
