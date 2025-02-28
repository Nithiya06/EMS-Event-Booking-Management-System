using EventManagementSystem.Data;
using EventManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EventManagementSystem.Controllers
{
    public class BookingController:Controller
    {
        private AppDbContext _context;
        public BookingController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Booking()
        {
            var bookings = _context.BookingConfirmation
                .Include(b => b.User)  // Include the User information
                .Include(b => b.Event) // Include the Event information
                .Select(b => new BookingViewModel
                {
                    UserId = b.User.Id,
                    UserEmail = b.User.Email,
                    UserName = b.User.Name,
                    EventName = b.Event.Name,
                    TicketCount = b.TicketCount,
                    TotalPrice = b.TotalPrice
                })
                .ToList(); // Fetch all bookings and map them to BookingViewModel

            return View(bookings);
        }

    }
    
}
