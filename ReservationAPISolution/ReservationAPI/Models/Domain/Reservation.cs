namespace ReservationAPI.Models.Domain
{
    public class Reservation
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User? User { get; set; }
        public Guid TableId { get; set; }
        public Table? Table { get; set; }
        public bool IsCanceled { get; set; }
        public DateTime ReservationDate { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}
