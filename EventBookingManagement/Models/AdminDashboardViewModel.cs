namespace EventManagementSystem.Models
{
    public class AdminDashboardViewModel
    {
        public int TotalUsers { get; set; }
        public int TotalEvents { get; set; }
        public int TotalBookings { get; set; }
        public List<Event> UpcomingEvents { get; set; }
    }
}
