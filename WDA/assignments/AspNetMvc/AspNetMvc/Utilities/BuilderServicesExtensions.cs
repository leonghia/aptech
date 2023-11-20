using AspNetMvc.Data;
using AspNetMvc.Entities;
using AspNetMvc.Repositories.GenericRepository;
using AspNetMvc.Services.ShopService;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;

namespace AspNetMvc.Utilities
{
    public static class BuilderServicesExtensions
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddAutoMapper(typeof(AutoMapperProfile));
            services
                .AddControllersWithViews()
                .AddNewtonsoftJson(setupAction =>
                {
                    setupAction.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    setupAction.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });
            services
                .AddDbContext<ShopContext>(options =>
                {
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
                });

            services.AddScoped<IGenericRepository<Category>, GenericRepository<Category>>();
            services.AddScoped<IGenericRepository<Product>, GenericRepository<Product>>();
            services.AddScoped<IShopService, ShopService>();         
        }
    }
}
