namespace ReservationAPI.Models.Dtos.Request
{
    public class CreateRestaurantDto
    {
        public string Name { get; set; } = string.Empty; 
        public string PhoneNumber { get; set; } = string.Empty; 
        public DateTime OpenDate { get; set; }
    }
}
