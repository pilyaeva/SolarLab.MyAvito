using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolarLab.MyAvito.Domain;

namespace SolarLab.MyAvito.Infrastructure.DataBase.Configurations
{
    public class AdvertisementConfiguration : IEntityTypeConfiguration<Advertisement>
    {
        public void Configure(EntityTypeBuilder<Advertisement> builder)
        {
            builder
                .ToTable("advertisement")
                .HasKey(t => t.Id);

            builder
                .Property(x => x.Id)
                .HasColumnName("id")
                .IsRequired();

            builder
                .Property(x => x.UserId)
                .HasColumnName("userId")
                .IsRequired();

            builder
                .Property(x => x.Title)
                .HasColumnName("title")
                .IsRequired()
                .HasMaxLength(70);

            builder
                .Property(x => x.Price)
                .HasColumnName("price")
                .IsRequired();

            builder
                .Property(x => x.Condition)
                .HasColumnName("condition")
                .IsRequired()
                .HasMaxLength(10);

            builder
                .Property(x => x.Description)
                .HasColumnName("description")
                .IsRequired()
                .HasMaxLength(1000);

            builder
                .Property(x => x.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired();
        }
    }
}
