using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.Application.Interfaces;
using Restaurant.Persistence.DatabaseContext;
using Restaurant.Persistence.Repositories;

namespace Restaurant.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
             options.UseSqlServer(configuration.GetConnectionString("AppDatabaseConnectionString")));

            services.AddScoped(typeof(IBaseRepository<>),typeof(BaseRepositoy<>));

            return services;
        }
    }
}
