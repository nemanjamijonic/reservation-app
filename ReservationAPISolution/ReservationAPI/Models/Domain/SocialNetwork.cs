namespace ReservationAPI.Models.Domain
{
    public class SocialNetwork
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Link { get; set; }
        public Guid RestaurantId { get; set; }
        public Restaurant? Restaurant { get; set; }
    }

}
