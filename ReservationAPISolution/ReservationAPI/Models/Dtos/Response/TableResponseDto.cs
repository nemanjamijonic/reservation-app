using ReservationAPI.Models.Domain;

namespace ReservationAPI.Models.Dtos.Response
{
    public class TableResponseDto
    {
        public Guid RestaurantId { get; set; }
        public Restaurant? Restaurant { get; set; }
        public int Capacity { get; set; }
        public bool IsReserved { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
