using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolarLab.MyAvito.Domain;

namespace SolarLab.MyAvito.Infrastructure.Database.Configurations
{
    public class FileConfiguration : IEntityTypeConfiguration<File>
    {
        public void Configure(EntityTypeBuilder<File> builder)
        {
            builder
                .ToTable("file")
                .HasKey(t => t.Id);

            builder
                .Property(x => x.Id)
                .HasColumnName("id")
                .IsRequired();

            builder
                .Property(x => x.AdvertisementId)
                .HasColumnName("advertisementId")
                .IsRequired();

            builder
                .Property(x => x.Name)
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(x => x.Content)
                .HasColumnName("content")
                .IsRequired();

            builder
                .Property(x => x.ContentType)
                .HasColumnName("contentType")
                .IsRequired()
                .HasMaxLength(255);

            builder
                .Property(x => x.Length)
                .HasColumnName("length")
                .IsRequired();
        }
    }
}
