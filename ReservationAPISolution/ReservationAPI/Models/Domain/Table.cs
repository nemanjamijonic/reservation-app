namespace ReservationAPI.Models.Domain
{
    public class Table
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public Restaurant? Restaurant { get; set; }
        public int Capacity { get; set; }
        public bool IsReserved { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }
    }

}
