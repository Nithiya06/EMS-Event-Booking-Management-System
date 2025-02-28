using System.ComponentModel.DataAnnotations;

namespace EventManagementSystem.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int AvailableSeats { get; set; }
        public decimal Price { get; set; }
        public TimeOnly Time { get; set; }

    }
}
