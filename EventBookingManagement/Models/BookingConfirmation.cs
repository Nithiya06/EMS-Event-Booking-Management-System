namespace EventManagementSystem.Models
{
    public class BookingConfirmation
    {
        public int Id { get; set; }
        // Foreign Key for User
        public int UserId { get; set; }
        public Users User { get; set; }  // Navigation Property
        // Foreign Key for Event
        public int EventId { get; set; }
        public Event Event { get; set; }  // Navigation Property
        // Booking Confirmation Details
        public string EventName { get; set; }
        public int TicketCount { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime EventDate { get; set; }
    }
}
