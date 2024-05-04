using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SolarLab.MyAvito.DbMigrator;
using System;
using System.Threading.Tasks;

var host = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddServices(hostContext.Configuration);
    }).Build();

await MigrateDatabaseAsync(host.Services);

await host.StartAsync();

static async Task MigrateDatabaseAsync(IServiceProvider serviceProvider)
{
    using var scope = serviceProvider.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<MigrationDbContext>();
    await context.Database.MigrateAsync();
}