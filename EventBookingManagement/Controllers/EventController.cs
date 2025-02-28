using EventManagementSystem.Data;
using EventManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace EventManagementSystem.Controllers
{
    public class EventController : Controller
    {
        private readonly AppDbContext _context;

        public EventController(AppDbContext context)
        {
            _context = context;
        }

        // Display event details:
        public IActionResult EventDetails(int id)
        {
            var eventDetails = _context.Event.Find(id);
            if (eventDetails == null)
            {
                return NotFound();
            }
            return View(eventDetails);
        }
        //create New Events
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Event events)
        {
            if(ModelState.IsValid)
            {
                _context.Event.Add(events);
                _context.SaveChanges();
                return RedirectToAction("Show");
            }
            return View(events);
        }
        //  Edit Events
        public IActionResult Edit(int id)
        {
            var eventItem = _context.Event.Find(id);
            if (eventItem == null)
            {
                return NotFound();
            }
            return View(eventItem);
        }
        [HttpPost]
        public IActionResult Edit(Event events)
        {
            if (ModelState.IsValid)
            {
                _context.Event.Update(events);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Data is successfully Updated!";
                return RedirectToAction("Show");

                
            }
            return View(events);
        }
        //Delete Events
        
        public IActionResult Delete(int id)
        {
            var eventItem = _context.Event.Find(id);
            if (eventItem == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _context.Event.Remove(eventItem);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Data is successfully Deleted!";
                return RedirectToAction("Show");


            }
            return View(eventItem);
        }
        // Show event list and filter data based on date and location to the admin
        public IActionResult Show(string? date, string? location)
        {
            var events = _context.Event.AsQueryable();

            if (!string.IsNullOrEmpty(date))
            {
                if (DateTime.TryParse(date, out DateTime parsedDate))
                {
                    events = events.Where(e => e.Date.Date == parsedDate.Date);
                }
            }

            if (!string.IsNullOrEmpty(location))
            {
                events = events.Where(e => e.Location.Contains(location));
            }

            return View(events.ToList());
        }
        // Show event list and filter data based on date and location to the User
        public IActionResult ShowUsers(string? date, string? location)
        {
            var events = _context.Event.AsQueryable();

            if (!string.IsNullOrEmpty(date))
            {
                if (DateTime.TryParse(date, out DateTime parsedDate))
                {
                    events = events.Where(e => e.Date.Date == parsedDate.Date);
                }
            }

            if (!string.IsNullOrEmpty(location))
            {
                events = events.Where(e => e.Location.Contains(location));
            }

            return View(events.ToList());
        }

        // Booking Tickets (POST)
        [HttpPost]
        public IActionResult BookTickets(int id, int ticketCount)
        {
            var eventItem = _context.Event.Find(id);
            if (eventItem == null)
            {
                return NotFound();
            }

            if (ticketCount <= 0 || ticketCount > eventItem.AvailableSeats)
            {
                TempData["ErrorMessage"] = "Not enough available seats.";
                return RedirectToAction("Show");
            }

            // Deduct available seats
            eventItem.AvailableSeats -= ticketCount;
            _context.SaveChanges();

            // Create a new booking confirmation
            var bookingConfirmation = new BookingConfirmation
            {
                UserId = 1,  // Replace with actual UserId
                EventId = eventItem.Id,
                EventName = eventItem.Name,
                TicketCount = ticketCount,
                TotalPrice = ticketCount * eventItem.Price,
                EventDate = eventItem.Date
            };

            // Save the booking confirmation to the database
            _context.BookingConfirmation.Add(bookingConfirmation);
            _context.SaveChanges();

            var totalPrice = ticketCount * eventItem.Price;

            return RedirectToAction("BookingConfirmation", new { id = eventItem.Id, ticketCount, totalPrice });
        }
        [HttpGet]
        public IActionResult BookingConfirmation(int id, int ticketCount, decimal totalPrice)
        {
            var eventItem = _context.Event.Find(id);
            if (eventItem == null)
            {
                return NotFound(); 
            }

            var bookingConfirmation = new BookingConfirmation
            {
                EventName = eventItem.Name,
                EventDate = eventItem.Date,
                TicketCount = ticketCount,
                TotalPrice = totalPrice
            };

            return View(bookingConfirmation);
        }
        [HttpPost]
        public IActionResult BookingConfirmation()
        {
              return RedirectToAction("Payment", "Event");  
        }
        public IActionResult Payment()
        {
            TempData["SuccessMessage"] = "Payment successful! Your booking is confirmed.";
            return View();
        }




    }
}
