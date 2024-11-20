using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ReservationAPI.Models.Domain;

namespace ReservationAPI.Configurations
{
    public class TableConfiguration : IEntityTypeConfiguration<Table>
    {
        public void Configure(EntityTypeBuilder<Table> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(a => a.Id)
                .ValueGeneratedOnAdd();

            builder.Property(t => t.RestaurantId)
               .IsRequired();

            builder.Property(t => t.Restaurant)
               .IsRequired();

            builder.Property(t => t.Capacity)
                .IsRequired();

            builder.Property(t => t.IsReserved)
                .IsRequired();

            builder.Property(t => t.CreatedAt)
                .IsRequired();

            builder.Property(t => t.IsDeleted)
                .IsRequired();

            builder.HasOne(t => t.Restaurant)
                   .WithMany(r => r.Tables)
                   .HasForeignKey(t => t.RestaurantId);
        }
    }
}
