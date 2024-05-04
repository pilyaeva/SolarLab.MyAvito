using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SolarLab.MyAvito.DbMigrator
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection service, IConfiguration configuration)
        {
            service.ConfigureDbConnections(configuration);
            return service;
        }

        public static IServiceCollection ConfigureDbConnections(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DbConnection");
            services.AddDbContext<MigrationDbContext>(options => options.UseNpgsql(connectionString));
            return services;
        }
    }
}
