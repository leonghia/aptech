using AspNetMvc.DatabaseContexts;
using AspNetMvc.Entities;
using AspNetMvc.Profiles;
using AspNetMvc.Repositories.GenericRepository;
using AspNetMvc.Services.ShopService;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;

namespace AspNetMvc.Extensions
{
    public static class BuilderServicesExtensions
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services
                .AddControllersWithViews(configure =>
                {
                    configure.ReturnHttpNotAcceptable = true;
                })
                .AddNewtonsoftJson(setupAction =>
                {
                    setupAction.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    setupAction.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });

            services
                .AddDbContext<ShopContext>(options =>
                {
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
                })
                .AddAutoMapper(typeof(AutoMapperProfile));               

            services.AddScoped<IGenericRepository<Category>, GenericRepository<Category>>();
            services.AddScoped<IGenericRepository<Product>, GenericRepository<Product>>();
            services.AddScoped<IShopService, ShopService>();
        }
    }
}
