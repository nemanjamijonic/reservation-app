using ReservationAPI.Data;
using ReservationAPI.Interfaces;
using ReservationAPI.Models.Domain;
using ReservationAPI.Models.Dtos.Request;
using ReservationAPI.Models.Dtos.Response;

namespace ReservationAPI.Repositories
{
    public class SocialNetworkRepository : ISocialNetworkRepository
    {
        private readonly ReservationsDbContext _context;
        public SocialNetworkRepository(ReservationsDbContext context)
        {
            _context = context;
        }
        public async Task<SocialNetworkResponseDto> CreateNewSocialNetworkAsync(CreateSocialNetworkDto createSocialNetworkDto)
        {
            var socialNetwork = new SocialNetwork
            {
                Name = createSocialNetworkDto.Name,
                Link = createSocialNetworkDto.Link,
                RestaurantId = createSocialNetworkDto.RestaurantId
            };

            await _context.SocialNetworks.AddAsync(socialNetwork);
            await _context.SaveChangesAsync();

            var sn = new SocialNetworkResponseDto
            {
                Name = createSocialNetworkDto.Name,
                Link = createSocialNetworkDto.Link,
                RestaurantId = createSocialNetworkDto.RestaurantId
            };

            return sn;
        }
    }
}
