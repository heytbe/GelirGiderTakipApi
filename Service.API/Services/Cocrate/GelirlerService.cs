using AutoMapper;
using Data.API.Context;
using Data.API.Dal.EfCategoryDal.Abstract;
using Data.API.FileUpload;
using Data.API.UnitOfWork.Abstract;
using Entity.API.Dto.Gelirler;
using Entity.API.Entities;
using Microsoft.EntityFrameworkCore;
using Service.API.Services.Abstract;
using SharedLibrary.Dto;

namespace Service.API.Services.Cocrate
{
    public class GelirlerService : IGelirlerService
    {
        private readonly IGelirlerDal _gelirlerDal;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly AppDbContext _context;
        public GelirlerService(IGelirlerDal gelirlerDal, IMapper mapper, IUnitOfWork unitOfWork,AppDbContext context)
        {
            _gelirlerDal = gelirlerDal;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _context = context;
        }

        public async Task<ResponseDto<NoDataDto>> DeleteGelir(int id)
        {
            var gelirCategory =await _gelirlerDal.GetByIdAsync(x => x.Id == id, x => x.Categories, x => x.Images);
            var deleteImages = await _context.Images.Where(x => x.GelirlerId == id).ToListAsync();
            _gelirlerDal.Delete(gelirCategory);
            _context.Images.RemoveRange(deleteImages);
            //_context.Gelirlers.RemoveRange(gelirCategory);
            await _unitOfWork.SaveAsync();
            return ResponseDto<NoDataDto>.Success(200);
        }

        public async Task<ResponseDto<GelirlerListeDto>> GelirCategoryImageAddAsync(GelirlerDto gelirlerDto, string fileDir = null)
        {
            var gelirler = await _gelirlerDal.CreateAndImageAddAsync(gelirlerDto,fileDir);
            await _gelirlerDal.AddAsync(gelirler);
            await _unitOfWork.SaveAsync();
            var automapper = _mapper.Map<GelirlerListeDto>(gelirler);
            return ResponseDto<GelirlerListeDto>.Success(automapper, 200);
        }

        public async Task<ResponseDto<List<GelirlerListeDto>>> GetAllAsync()
        {
            var gelirler = await _gelirlerDal.GetAllAsync(x => x.IsDeleted == false, x => x.Categories, x => x.Images);
            if(gelirler.Count() == 0)
            {
               return ResponseDto<List<GelirlerListeDto>>.Fail("No Result", 404,true);
            }
            var autoamapper = _mapper.Map<List<GelirlerListeDto>>(gelirler);
            return ResponseDto<List<GelirlerListeDto>>.Success(autoamapper,200);
        }

        public async Task<ResponseDto<NoDataDto>> UpdateGelirlerCategory(GelirlerUpdateDto gelirlerDto, int id)
        {
            var gelirler = await _gelirlerDal.UpdateGelirCategoryAndImage(gelirlerDto, id);
            if(gelirler == null)
            {
                return ResponseDto<NoDataDto>.Fail("No Result", 404, true);
            }
            _gelirlerDal.Update(gelirler);
            await _unitOfWork.SaveAsync();
            return ResponseDto<NoDataDto>.Success(200);
        }

        public async Task<ResponseDto<NoDataDto>> UpdateImageGelirlerImages(GelirImageUpdateDto gelirImageUpdateDto, int gelirid, int imageid, string fileDir)
        {
            var gelirler = await _context.Images.FirstOrDefaultAsync(x => x.Id == imageid);
            if(gelirler == null)
            {
                return ResponseDto<NoDataDto>.Fail("Id Not Found",404,true);
            }

            if(gelirler.GelirlerId != gelirid)
            {
                return ResponseDto<NoDataDto>.Fail("Gelir Id Not Found", 404, true);
            }

            Upload upload = new Upload();
            var uploadFile = await upload.Uploader(gelirImageUpdateDto.Files, fileDir);

            gelirler.ImageName = uploadFile[0];
            gelirler.ImageFile = uploadFile[1];
            gelirler.ImageSize = uploadFile[2];

            _context.Images.Update(gelirler);
            await _unitOfWork.SaveAsync();
            return ResponseDto<NoDataDto>.Success(200);
        }
    }
}
