using Data.API.Repositories.Abstract;
using Entity.API.Dto.Gelirler;
using Entity.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.API.Dal.EfCategoryDal.Abstract
{
    public interface IGelirlerDal:IGenericRepository<Gelirler>
    {
        Task<Gelirler> CreateAndImageAddAsync(GelirlerDto gelirlerCreateDto,string fileDir = null);
        Task<Gelirler> UpdateGelirCategoryAndImage(GelirlerUpdateDto gelirlerDto,int id);
    }
}
