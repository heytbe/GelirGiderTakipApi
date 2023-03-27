using Data.API.Repositories.Abstract;
using Entity.API.Dto.Category;
using Entity.API.Entities;

namespace Data.API.Dal.EfCategory.Abstract
{
    public interface ICategoryDal:IGenericRepository<Category>
    {
        Task<Category> CategoryAndImageAddAsync(CategoryDto categoryDal,string FileDir);
        Task<Category> CategoryAndImageUpdateAsync(CategoryDto categoryDal,int id,string FileDir = null);
    }
}
