using Microsoft.EntityFrameworkCore;
using SolarLab.MyAvito.Domain;
using SolarLab.MyAvito.Infrastructure.DataBase.Configurations;

namespace SolarLab.MyAvito.Infrastructure.DataBase
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        public DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
