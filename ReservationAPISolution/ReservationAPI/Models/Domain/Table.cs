namespace ReservationAPI.Models.Domain
{
    public class Table
    {
        public Guid Id { get; set; }
        public Guid RestaurantId { get; set; }
        public Restaurant? Restaurant { get; set; }
        public int Capacity { get; set; }
        public bool IsReserved { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }
    }

}
