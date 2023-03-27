using AutoMapper;
using Data.API.Context;
using Data.API.Dal.EfCategory.Abstract;
using Data.API.UnitOfWork.Abstract;
using Entity.API.Dto.Category;
using Entity.API.Entities;
using Service.API.Services.Abstract;
using SharedLibrary.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.API.Services.Cocrate
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly AppDbContext _context;
        public CategoryService(ICategoryDal categoryDal,IMapper mapper,IUnitOfWork unitOfWork,AppDbContext context)
        {
            _categoryDal = categoryDal;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _context = context;
        }

        public async Task<ResponseDto<CategoryListeOlusturDto>> AddAsync(CategoryDto categoryDto,string FileDir)
        {
            var categorycreate = await _categoryDal.CategoryAndImageAddAsync(categoryDto, FileDir);
            //var automapper = _mapper.Map<Category>(categorycreate);
            await _categoryDal.AddAsync(categorycreate);
            await _unitOfWork.SaveAsync();
            var response = _mapper.Map<CategoryListeOlusturDto>(categorycreate);
            return ResponseDto<CategoryListeOlusturDto>.Success(response, 200);
        }

        public async Task<ResponseDto<CategoryListeOlusturDto>> CategoryAndImageUpdate(CategoryDto categoryDto, int id, string FileDir=null)
        {
            var category = await _categoryDal.CategoryAndImageUpdateAsync(categoryDto, id, FileDir);
            _categoryDal.Update(category);
            await _unitOfWork.SaveAsync();
            var automapper = _mapper.Map<CategoryListeOlusturDto>(category);
            return ResponseDto<CategoryListeOlusturDto>.Success(automapper, 200);
        }

        public async Task<ResponseDto<NoDataDto>> DeleteAsync(int id)
        {
            var entity =await _categoryDal.GetByIdAsync(x => x.Id == id, x => x.Images);
            _context.Images.Remove(entity.Images);
             _categoryDal.Delete(entity);
            await _unitOfWork.SaveAsync();
            return ResponseDto<NoDataDto>.Success(200);
        }

        public async Task<ResponseDto<List<CategoryListeOlusturDto>>> GetAllAsync()
        {
            var categoryAndImage =  await _categoryDal.GetAllAsync(x => x.IsDeleted == false, x => x.Images);
            var automapper = _mapper.Map<List<CategoryListeOlusturDto>>(categoryAndImage);
            return ResponseDto<List<CategoryListeOlusturDto>>.Success(automapper, 200);
        }

        public async Task<ResponseDto<CategoryListeOlusturDto>> GetByIdList(int id)
        {
            var categoriAndImageList = await _categoryDal.GetByIdAsync(x => x.Id == id,x => x.Images);
            var automapper = _mapper.Map<CategoryListeOlusturDto>(categoriAndImageList);
            return ResponseDto<CategoryListeOlusturDto>.Success(automapper, 200);
        }

        
    }
}
