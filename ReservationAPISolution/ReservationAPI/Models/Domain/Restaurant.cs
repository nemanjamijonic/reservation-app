using System.Net;

namespace ReservationAPI.Models.Domain
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public Address? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime OpenDate { get; set; }
        public List<SocialNetwork> SocialNetworks { get; set; } = new();
        public List<Table> Tables { get; set; } = new();
        public List<Review> Reviews { get; set; } = new();
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}
