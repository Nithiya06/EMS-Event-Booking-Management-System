using EventManagementSystem.Data;
using EventManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementSystem.Controllers
{
    public class HomeController:Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult AdminDashboard()
        {
            var model = new AdminDashboardViewModel
            {
                TotalUsers = _context.Users.Count(),
                TotalEvents = _context.Event.Count(),
                TotalBookings = _context.BookingConfirmation.Count(),
                UpcomingEvents = _context.Event.Where(e => e.Date > DateTime.Now).ToList()  // Example: upcoming events
            };

            return View(model);
        }
        public IActionResult Index()
        {
               return View();
        }
    

        [HttpPost]
        public IActionResult Index(Admin admin)
        {
            if (!ModelState.IsValid)
            {
                return View(admin); 
            }

            var admins = _context.Admin.FirstOrDefault(a => a.Username == admin.Username);
            if (admins != null && admins.Password == admin.Password)
            {
                return RedirectToAction("AdminDashboard");
            }

            return View("Error");
        }

        public IActionResult Print()
        {
            var admins = _context.Admin.ToList();  
            return View(admins);
        }
    }
}
