using Data.API.Dal.EfCategory.Abstract;
using Data.API.Dal.EfCategoryDal.Abstract;
using Data.API.Dal.EfCategoryDal.Concrate;
using Data.API.Dal.EfGiderlerDal.Abstract;
using Data.API.Dal.EfGiderlerDal.Concrate;
using Data.API.Repositories.Abstract;
using Data.API.Repositories.Concrate;
using Data.API.UnitOfWork.Abstract;
using Data.API.UnitOfWork.Concrate;
using Microsoft.Extensions.DependencyInjection;
using Service.API.Services.Abstract;
using Service.API.Services.Cocrate;
using System.Reflection;

namespace Service.API.Extension
{
    public static class DataServiceLoadExtensions
    {
        public static IServiceCollection LoadServiceDataExtensions(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddAutoMapper(assembly);
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICategoryDal, CategoryDal>();
            services.AddScoped<IGelirlerDal,GelirlerDal>();
            services.AddScoped<IGelirlerService,GelirlerService>();
            services.AddScoped<IGiderlerDal,GiderlerDal>();
            services.AddScoped<IGiderlerService,GiderlerService>();
            return services;
        }
    }
}
