using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ReservationAPI.Models.Domain;

namespace ReservationAPI.Configurations
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(a => a.Id)
                .ValueGeneratedOnAdd();

            builder.Property(r => r.UserId)
                .IsRequired();

            builder.Property(r => r.User)
                .IsRequired();

            builder.Property(r => r.TableId)
                .IsRequired();

            builder.Property(r => r.Table)
                .IsRequired();

            builder.Property(r => r.IsCanceled)
                .IsRequired();

            builder.Property(r => r.ReservationDate)
                .IsRequired();

            builder.Property(r => r.CreatedAt)
                .IsRequired();

            builder.HasOne(r => r.User)
                   .WithMany()
                   .HasForeignKey(r => r.UserId);

            builder.HasOne(r => r.Table)
                   .WithMany()
                   .HasForeignKey(r => r.TableId);

        }
    }
}
