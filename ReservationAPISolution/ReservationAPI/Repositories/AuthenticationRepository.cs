using Microsoft.EntityFrameworkCore;
using ReservationAPI.Data;
using ReservationAPI.Helpers;
using ReservationAPI.Interfaces;
using ReservationAPI.Models.Domain;
using ReservationAPI.Models.Dtos;

namespace ReservationAPI.Repositories
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly ReservationsDbContext _context;
        private readonly TokenHelper _tokenHelper;

        public AuthenticationRepository(ReservationsDbContext context, TokenHelper tokenHelper)
        {
            _context = context;
            _tokenHelper = tokenHelper;
        }

        public async Task<AuthResponseDto?> LoginAsync(LoginDto loginDto)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == loginDto.Username && !u.IsDeleted);

            if (user == null || !HashHelper.VerifyPassword(loginDto.Password, user.PasswordHash))
            {
                return null;
            }
            var token = _tokenHelper.GenerateToken(user);

            return new AuthResponseDto
            {
                Token = token,
                UserId = user.Id,
                Username = user.Username ?? ""
            };
        }

        public async Task<AuthResponseDto> RegisterAsync(RegisterDto registerDto)
        {
            var usernameExists = await _context.Users.AnyAsync(u => u.Username == registerDto.Username && !u.IsDeleted);
            var emailExists = await _context.Users.AnyAsync(u => u.Email == registerDto.Email && !u.IsDeleted);

            if (usernameExists || emailExists)
            {
                throw new InvalidOperationException("Username or email already exists.");
            }

            var newUser = new User
            {
                Username = registerDto.Username,
                PasswordHash = registerDto.Password,
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                IsDeleted = false,
                Email = registerDto.Email,
                Role = registerDto.Role,
                Gender = registerDto.Gender,
                DateOfBirth = registerDto.DateOfBirth,
                CreatedAt = DateTime.UtcNow,
            };

            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();

            var token = _tokenHelper.GenerateToken(newUser);

            return new AuthResponseDto
            {
                Token = token,
                UserId = newUser.Id,
                Username = newUser.Username
            };
        }
    }
}
