using ReservationAPI.Models.Dtos.Request;
using ReservationAPI.Models.Dtos.Response;

namespace ReservationAPI.Interfaces
{
    public interface ISocialNetworkRepository
    {
        Task<SocialNetworkResponseDto> CreateNewSocialNetworkAsync(CreateSocialNetworkDto createSocialNetworkDto);
    }
}
