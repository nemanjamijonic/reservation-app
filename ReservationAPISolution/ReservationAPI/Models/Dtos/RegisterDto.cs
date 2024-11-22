using ReservationAPI.Models.Enums;

namespace ReservationAPI.Models.Dtos
{
    public class RegisterDto
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public Role Role { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
