namespace EventManagementSystem.Models
{
    public class BookingViewModel
    {
        public int UserId {  get; set; }
        public string UserName { get; set; }
        public string UserEmail {  get; set; }
        public string EventName {  get; set; }
        public int TicketCount {  get; set; }
        public decimal TotalPrice {  get; set; }
    }
}
