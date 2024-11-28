namespace ReservationAPI.Models.Dtos.Request
{
    public class CreateSocialNetworkDto
    {
        public string? Name { get; set; } = string.Empty;
        public string? Link { get; set; } = string.Empty;
        public Guid RestaurantId { get; set; }
    }
}
