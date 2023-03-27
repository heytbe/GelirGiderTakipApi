using AutoMapper;
using Data.API.FileUpload;
using Data.API.Context;
using Data.API.Dal.EfCategory.Abstract;
using Data.API.Repositories.Concrate;
using Entity.API.Dto.Category;
using Entity.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.API.Dal.EfCategoryDal.Concrate
{
    public class CategoryDal : GenericRepository<Category>, ICategoryDal
    {
        private readonly AppDbContext _context;
        public CategoryDal(AppDbContext context) : base(context)
        {
           _context = context;
        }

        public async Task<Category> CategoryAndImageAddAsync(CategoryDto categoryDto,string FileDir)
        {
            Upload upload = new Upload();
            var uploadFile = await upload.Uploader(categoryDto.File, FileDir);
            Category category = new Category();
            category.CategoryName = categoryDto.CategoryName;
            category.Description = categoryDto.Description;
            category.Images = new Images()
            {
                ImageName = uploadFile[0],
                ImageFile= uploadFile[1],
                ImageSize = uploadFile[2]
            };
            return  category;
        }

        public async Task<Category> CategoryAndImageUpdateAsync(CategoryDto categoryDto,int id ,string FileDir = null)
        {

            var categoryAndImageList = _context.Categories.Include(x => x.Images).FirstOrDefault(x => x.Id == id);
            if (categoryAndImageList != null) 
            {
                categoryAndImageList.CategoryName = categoryDto.CategoryName;
                categoryAndImageList.Description = categoryDto.Description;
                if (categoryDto.File != null)
                {
                    _context.Images.Remove(categoryAndImageList.Images);   
                    Upload upload = new Upload();
                    var uploadFile = await upload.Uploader(categoryDto.File, FileDir);
                    categoryAndImageList.Images = new Images()
                    {
                        ImageName = uploadFile[0],
                        ImageFile = uploadFile[1],
                        ImageSize = uploadFile[2]
                    };
                }
            }
            return categoryAndImageList;
        }
    }
}
