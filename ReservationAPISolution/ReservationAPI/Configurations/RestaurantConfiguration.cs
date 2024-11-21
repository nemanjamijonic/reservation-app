using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ReservationAPI.Models.Domain;

namespace ReservationAPI.Configurations
{
    public class RestaurantConfiguration : IEntityTypeConfiguration<Restaurant>
    {
        public void Configure(EntityTypeBuilder<Restaurant> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(a => a.Id)
                .ValueGeneratedOnAdd();

            builder.Property(r => r.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(r => r.PhoneNumber)
                .HasMaxLength(25)
                .IsRequired();

            builder.Property(r => r.OpenDate)
                .IsRequired();

            builder.Property(r => r.IsDeleted)
                .IsRequired();

            builder.Property(r => r.CreatedAt)
                .IsRequired();

            builder.HasOne(r => r.Address)
                   .WithOne(a => a.Restaurant)
                   .HasForeignKey<Address>(a => a.RestaurantId);
        }
    }
}
