using Microsoft.EntityFrameworkCore;
using SolarLab.MyAvito.Infrastructure.DataBase;

namespace SolarLab.MyAvito.DbMigrator
{
    public class MigrationDbContext : ApplicationDbContext
    {
        public MigrationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }
    }
}
