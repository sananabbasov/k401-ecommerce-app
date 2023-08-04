using System;
using AutoMapper;
using K401Ecommerce.Business.Abstract;
using K401Ecommerce.Business.AutoMapper;
using K401Ecommerce.Business.Concrete;
using K401Ecommerce.DataAccess.Abstract;
using K401Ecommerce.DataAccess.Abstract.DataSeeding;
using K401Ecommerce.DataAccess.Concrete.DataSeeding;
using K401Ecommerce.DataAccess.Concrete.EntityFramework;
using Microsoft.Extensions.DependencyInjection;

namespace K401Ecommerce.Business.DependencyResolver.DependencyRegister
{
	public static class ServiceRegisteration
	{
		public static void Create(this IServiceCollection services)
		{
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDal, EfCategoryDal>();

            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<IProductDal, EfProductDal>();

            services.AddScoped<IOrderService, OrderManager>();
            services.AddScoped<IOrderDal, EfOrderDal>();

            services.AddScoped<IDataSeeder, EfDataSeeder>();

            services.AddScoped<AppDbContext>();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
	}
}

