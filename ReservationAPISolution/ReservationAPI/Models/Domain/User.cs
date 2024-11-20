using ReservationAPI.Helpers;
using ReservationAPI.Models.Enums;

namespace ReservationAPI.Models.Domain
{
    public class User
    {
        private string _passwordHash = string.Empty;
        public int UserId { get; set; }
        public string? Username { get; set; }
        public string PasswordHash
        {
            get { return _passwordHash; }
            set { _passwordHash = HashHelper.HashPassword(value); }
        }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool IsDeleted { get; set; }
        public string? Email { get; set; }
        public Role Role { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
