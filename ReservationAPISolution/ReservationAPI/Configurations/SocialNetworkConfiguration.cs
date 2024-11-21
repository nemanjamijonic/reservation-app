using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ReservationAPI.Models.Domain;

namespace ReservationAPI.Configurations
{
    public class SocialNetworkConfiguration : IEntityTypeConfiguration<SocialNetwork>
    {
        public void Configure(EntityTypeBuilder<SocialNetwork> builder)
        {
            builder.HasKey(sn => sn.Id);

            builder.Property(a => a.Id)
                .ValueGeneratedOnAdd();

            builder.Property(sn => sn.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(sn => sn.Link)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(sn => sn.RestaurantId)
                .IsRequired();

            builder.HasOne(sn => sn.Restaurant)
                   .WithMany(r => r.SocialNetworks)
                   .HasForeignKey(sn => sn.RestaurantId);
        }
    }
}
