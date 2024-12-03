using Microsoft.IdentityModel.Tokens;
using ReservationAPI.Models.Domain;
using Serilog;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ReservationAPI.Helpers
{
    public class TokenHelper
    {
        private readonly IConfiguration? _configuration;

        public TokenHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(User user)
        {
            Log.Information("Starting token generation for user: {UserId}, Username: {Username}", user.Id, user.Username);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email ?? string.Empty),
                new Claim("username", user.Username ?? string.Empty),
                new Claim("role", user.Role.ToString()),
                new Claim("userid", user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var jwtKey = _configuration?["Jwt:Key"];
            if (string.IsNullOrEmpty(jwtKey))
            {
                Log.Error("JWT key is missing in configuration.");
                throw new ArgumentNullException("Jwt:Key", "JWT key is not configured.");
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = _configuration?["Jwt:Issuer"],
                Audience = _configuration?["Jwt:Audience"],
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            Log.Information("Token successfully generated for user: {UserId}, Username: {Username}", user.Id, user.Username);
            return tokenHandler.WriteToken(token);
        }
    }
}
