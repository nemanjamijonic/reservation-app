namespace ReservationAPI.Models.Domain
{
    public class Reservation
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public int TableId { get; set; }
        public Table? Table { get; set; }
        public bool Canceled { get; set; }
        public DateTime ReservationDate { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}
