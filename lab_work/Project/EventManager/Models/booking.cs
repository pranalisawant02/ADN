namespace EventManager.Models
{
    public class Booking
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public int EventId { get; set; }

        public int TicketsBooked { get; set; }
    }
}