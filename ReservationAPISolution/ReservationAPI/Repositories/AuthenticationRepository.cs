using Microsoft.EntityFrameworkCore;
using ReservationAPI.Data;
using ReservationAPI.Helpers;
using ReservationAPI.Interfaces;
using ReservationAPI.Models.Domain;
using ReservationAPI.Models.Dtos.Request;
using ReservationAPI.Models.Dtos.Response;
using Serilog;

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
            Log.Information("Login attempt for user: {Username}", loginDto.Username);

            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == loginDto.Username && !u.IsDeleted);

            if (user == null)
            {
                Log.Warning("Login failed for user: {Username}. User not found or deleted.", loginDto.Username);
                return null;
            }

            if (!HashHelper.VerifyPassword(loginDto.Password, user.PasswordHash))
            {
                Log.Warning("Login failed for user: {Username}. Incorrect password.", loginDto.Username);
                return null;
            }

            var token = _tokenHelper.GenerateToken(user);
            Log.Information("Login successful for user: {Username}. Token generated.", loginDto.Username);

            return new AuthResponseDto
            {
                Token = token,
                UserId = user.Id,
                Username = user.Username ?? ""
            };
        }


        public async Task<AuthResponseDto> RegisterAsync(RegisterDto registerDto)
        {
            Log.Information("Registration attempt for username: {Username} and email: {Email}", registerDto.Username, registerDto.Email);

            var usernameExists = await _context.Users.AnyAsync(u => u.Username == registerDto.Username && !u.IsDeleted);
            var emailExists = await _context.Users.AnyAsync(u => u.Email == registerDto.Email && !u.IsDeleted);

            if (usernameExists || emailExists)
            {
                Log.Warning("Registration failed for username: {Username} or email: {Email}. Already exists.", registerDto.Username, registerDto.Email);
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

            Log.Information("Creating new user: {Username}", newUser.Username);

            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();

            var token = _tokenHelper.GenerateToken(newUser);

            Log.Information("Registration successful for user: {Username}. Token generated.", newUser.Username);

            return new AuthResponseDto
            {
                Token = token,
                UserId = newUser.Id,
                Username = newUser.Username
            };
        }

    }
}
