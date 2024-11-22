using ReservationAPI.Models.Dtos;

namespace ReservationAPI.Interfaces
{
    public interface IAuthenticationRepository
    {
        Task<AuthResponseDto> RegisterAsync(RegisterDto registerDto);
        Task<AuthResponseDto?> LoginAsync(LoginDto loginDto);
    }
}
