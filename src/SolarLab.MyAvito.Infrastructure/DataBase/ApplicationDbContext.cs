using Microsoft.EntityFrameworkCore;
using SolarLab.MyAvito.Domain;
using SolarLab.MyAvito.Infrastructure.Database.Configurations;

namespace SolarLab.MyAvito.Infrastructure.DataBase
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Advertisement> Advertisements { get; set; } = null!;
        public DbSet<File> Files { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new AdvertisementConfiguration());
            modelBuilder.ApplyConfiguration(new FileConfiguration());
        }
    }
}
