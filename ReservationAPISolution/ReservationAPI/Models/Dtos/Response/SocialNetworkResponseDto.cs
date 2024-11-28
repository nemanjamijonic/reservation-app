namespace ReservationAPI.Models.Dtos.Response
{
    public class SocialNetworkResponseDto
    {
        public string? Name { get; set; } = string.Empty;
        public string? Link { get; set; } = string.Empty;
        public Guid RestaurantId {  get; set; }
    }
}
