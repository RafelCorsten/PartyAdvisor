using DataBase.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataBase
{
    public static class ServiceRegistration
    {
        public static void AddDatabaseInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PartyDbContext>(options =>
            {
                options.UseSqlServer(configuration["ConnectionString..DefaultConnection"]);
            }, ServiceLifetime.Scoped);
        }
    }
}
