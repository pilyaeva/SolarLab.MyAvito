using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolarLab.MyAvito.Domain;

namespace SolarLab.MyAvito.Infrastructure.Database.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .ToTable("users")
                .HasKey(t => t.Id);

            builder
                .Property(x => x.Id)
                .HasColumnName("id")
                .IsRequired();

            builder
                .Property(x => x.Login)
                .HasColumnName("login")
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(x => x.Password)
                .HasColumnName("password")
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
