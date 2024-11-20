using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ReservationAPI.Models.Domain;

namespace ReservationAPI.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id)
                .ValueGeneratedOnAdd();

            builder.Property(a => a.Street)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(a => a.Number)
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(a => a.City)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(a => a.RestaurantId)
                .IsRequired();

            builder.Property(a => a.Restaurant)
                .IsRequired();
        }
    }
}
