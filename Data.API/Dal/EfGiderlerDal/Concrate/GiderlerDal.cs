using Data.API.Context;
using Data.API.Dal.EfGiderlerDal.Abstract;
using Data.API.FileUpload;
using Data.API.Repositories.Concrate;
using Entity.API.Dto.Giderler;
using Entity.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.API.Dal.EfGiderlerDal.Concrate
{
    public class GiderlerDal : GenericRepository<Giderler>, IGiderlerDal
    {
        public GiderlerDal(AppDbContext context) : base(context)
        {
        }

        public async Task<Giderler> AddGiderlerAsync(GiderlerAddDto giderlerAddDto, string fileDir)
        {
            Giderler giderler = new Giderler();
            giderler.GiderName = giderlerAddDto.GiderName;
            giderler.GiderMiktari = giderlerAddDto.GiderMiktari;
            giderler.NerdeHarcandi = giderlerAddDto.NerdeHarcandi;
            giderler.Description = giderlerAddDto.Description;

            if(giderlerAddDto.File.Count > 0)
            {
                Upload upload = new Upload();
                foreach (var item in giderlerAddDto.File)
                {
                    var uploadFile = await upload.Uploader(item, fileDir);
                    giderler.Images.Add(new Images()
                    {
                        ImageName = uploadFile[0],
                        ImageFile = uploadFile[1],
                        ImageSize = uploadFile[2]
                    });
                }
            }

            if(giderlerAddDto.Categories.Count> 0)
            {
                foreach (var item in giderlerAddDto.Categories)
                {
                    giderler.Categories.Add(new GiderCategory()
                    {
                        CategoryId = item
                    });
                }
            }

            return giderler;
        }
    }
}
