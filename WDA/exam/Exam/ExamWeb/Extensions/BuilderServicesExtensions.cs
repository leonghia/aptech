using ExamWeb.DatabaseContexts;
using ExamWeb.Entities;
using ExamWeb.Profiles;
using ExamWeb.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace ExamWeb.Extensions
{
    public static class BuilderServicesExtensions
    {
        public static void Configure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllersWithViews();

            services
                .AddDbContext<ExamContext>(optionsAction =>
            {
                optionsAction.UseSqlServer(configuration.GetConnectionString("CustomConnection"));
            })
                .AddAutoMapper(typeof(AutoMapperProfile));

            services.AddScoped<IGenericRepository<Department>, GenericRepository<Department>>();
            services.AddScoped<IGenericRepository<Employee>, GenericRepository<Employee>>();
        }
    }
}
