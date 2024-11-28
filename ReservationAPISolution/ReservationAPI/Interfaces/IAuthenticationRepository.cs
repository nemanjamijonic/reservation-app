using ReservationAPI.Models.Dtos.Request;
using ReservationAPI.Models.Dtos.Response;

namespace ReservationAPI.Interfaces
{
    public interface IAuthenticationRepository
    {
        Task<AuthResponseDto> RegisterAsync(RegisterDto registerDto);
        Task<AuthResponseDto?> LoginAsync(LoginDto loginDto);
    }
}
