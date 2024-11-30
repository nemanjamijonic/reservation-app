namespace ReservationAPI.Models.Dtos.Request
{
    public class CreateTableDto
    {
        public Guid RestaurantId { get; set; }
        public int Capacity { get; set; }
    }
}
