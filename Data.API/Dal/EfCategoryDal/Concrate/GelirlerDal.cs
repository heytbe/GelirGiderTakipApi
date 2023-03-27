using Data.API.Context;
using Data.API.Dal.EfCategoryDal.Abstract;
using Data.API.FileUpload;
using Data.API.Repositories.Abstract;
using Data.API.Repositories.Concrate;
using Entity.API.Dto.Gelirler;
using Entity.API.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace Data.API.Dal.EfCategoryDal.Concrate
{
    public class GelirlerDal : GenericRepository<Gelirler>, IGelirlerDal
    {
        private readonly AppDbContext _context;
        public GelirlerDal(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Gelirler> CreateAndImageAddAsync(GelirlerDto gelirlerCreateDto,string fileDir = null)
        {
            Gelirler gelirler = new Gelirler();
            gelirler.GelirAdi = gelirlerCreateDto.GelirAdi;
            gelirler.GelirMiktari = Convert.ToDecimal(gelirlerCreateDto.GelirMiktari);
            gelirler.GelirKimden = gelirlerCreateDto.GelirKimden;
            gelirler.GelirYolu = gelirlerCreateDto.GelirYolu;

            if (gelirlerCreateDto.Files != null) 
            {
                Upload upload = new Upload();

                foreach (var item in gelirlerCreateDto.Files)
                {
                   var uploadFile = await upload.Uploader(item, fileDir);
                    gelirler.Images.Add(new Images()
                    {
                        ImageName = uploadFile[0],
                        ImageFile= uploadFile[1],
                        ImageSize = uploadFile[2]
                    });
                }
            }

            foreach (var item in gelirlerCreateDto.Categories)
            {
                gelirler.Categories.Add(new GelirCategory()
                {
                    CategoryId = item
                });
            }
            return gelirler;
        }

        public async Task<Gelirler> UpdateGelirCategoryAndImage(GelirlerUpdateDto gelirlerDto,int id)
        {
            var gelirler = _context.Gelirlers.Include(x => x.Categories).FirstOrDefault(x => x.Id == id);
            if(gelirler == null)
            {
                return null;
            }

            if(gelirler.GelirAdi != gelirlerDto.GelirAdi)
            {
                gelirler.GelirAdi = gelirlerDto.GelirAdi;
            }

            if (gelirler.GelirMiktari != gelirlerDto.GelirMiktari)
            {
                gelirler.GelirMiktari = Convert.ToDecimal(gelirlerDto.GelirMiktari);
            }

            if (gelirler.GelirYolu != gelirlerDto.GelirYolu)
            {
                gelirler.GelirYolu = gelirlerDto.GelirYolu;
            }

            if (gelirler.GelirKimden != gelirlerDto.GelirKimden)
            {
                gelirler.GelirKimden = gelirlerDto.GelirKimden;
            }

            if (gelirlerDto.Categories != null)
            {
                var category = await _context.GelirCategories.Where(x => x.GelirlerId == id).ToListAsync();
                _context.GelirCategories.RemoveRange(category);

                foreach (var item in gelirlerDto.Categories)
                {
                    gelirler.Categories.Add(new GelirCategory()
                    {
                        CategoryId = item
                    });
                }
            }
            return gelirler;
        }
    }
}
