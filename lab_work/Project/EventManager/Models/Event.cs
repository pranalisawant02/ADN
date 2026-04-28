namespace EventManager.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Event
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Location { get; set; }

        public DateTime Date { get; set; }

        public int TicketPrice { get; set; }

        public int AvailableSeats { get; set; }
    }
}