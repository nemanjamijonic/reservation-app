namespace ReservationAPI.Models.Domain
{
    public class Review
    {
        public Guid Id { get; set; }
        public double Rating { get; set; }
        public string? Comment { get; set; }
        public bool IsDeleted { get; set; }
        public Guid UserId { get; set; }
        public User? User { get; set; }
        public Guid RestaurantId { get; set; }
        public Restaurant? Restaurant { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}
