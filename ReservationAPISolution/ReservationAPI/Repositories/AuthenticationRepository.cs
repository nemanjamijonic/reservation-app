using ReservationAPI.Interfaces;
using ReservationAPI.Models.Dtos;

namespace ReservationAPI.Repositories
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        public Task<AuthResponseDto?> LoginAsync(LoginDto loginDto)
        {
            throw new NotImplementedException();
        }

        public Task<AuthResponseDto> RegisterAsync(RegisterDto registerDto)
        {
            throw new NotImplementedException();
        }
    }
}
