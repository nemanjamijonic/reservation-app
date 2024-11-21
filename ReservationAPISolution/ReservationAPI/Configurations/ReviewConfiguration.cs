using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ReservationAPI.Models.Domain;

namespace ReservationAPI.Configurations
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(a => a.Id)
                .ValueGeneratedOnAdd();

            builder.Property(r => r.Rating)
                .HasPrecision(3, 2)
                .IsRequired();

            builder.Property(r => r.Comment)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(r => r.IsDeleted)
                .IsRequired();

            builder.Property(r => r.UserId)
                .IsRequired();

            builder.Property(r => r.RestaurantId)
                .IsRequired();

            builder.HasOne(r => r.User)
                   .WithMany()
                   .HasForeignKey(r => r.UserId);

            builder.HasOne(r => r.Restaurant)
                   .WithMany(r => r.Reviews)
                   .HasForeignKey(r => r.RestaurantId);
        }
    }
}
