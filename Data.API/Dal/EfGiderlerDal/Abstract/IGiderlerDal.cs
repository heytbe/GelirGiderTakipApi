using Data.API.Repositories.Abstract;
using Data.API.Repositories.Concrate;
using Entity.API.Dto.Giderler;
using Entity.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.API.Dal.EfGiderlerDal.Abstract
{
    public interface IGiderlerDal:IGenericRepository<Giderler>
    {
        Task<Giderler> AddGiderlerAsync(GiderlerAddDto giderlerAddDto,string fileDir);
    }
}
