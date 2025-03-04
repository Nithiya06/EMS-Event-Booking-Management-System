Event Booking System
1. User Flow
   
   1.1. Registration / Login
  	New User:
   
    User visits the website and clicks on Sign Up.
    User provides basic details (name, email, password).
    After successful registration, the user can log in.
   
    1.2 Existing User:
   
    User clicks on Login and enters their credentials (email, password).
  
    
3.	View Events
   
    Once logged in, the user is redirected to the Event List page.
    This page displays all available events (name, date, description, and available seats).
    The user can filter events based on the date or location.

3.  Book Tickets

    The user selects an event they are interested in.
    A page showing the event details (price, available seats, time) is displayed.
    The user can choose how many tickets to book.
    If there are available seats, the user clicks on the Book Now button to proceed.
    The user confirms the booking and completes the payment (if required).
  
4.  Booking Confirmation
   
    The system checks if the tickets are still available.
    If available, the booking is confirmed, and a booking confirmation message is shown along with booking details (event name, date, number of tickets).
    The booking is stored in the database, linked to the user's profile.
    The user can also view their booked events in the dashboard.

5.  Cancel Booking
   
    The user can navigate to their Dashboard and view their current bookings.
    For any booking, there will be an option to cancel.
    Upon cancellation, the event tickets are refunded (if applicable) and the booking is removed from the user's profile.

Admin Flow

1.	  Admin Login
   
	  Admins login is for Master process.
  	After successful login, the admin is directed to the Admin Dashboard.

2.   Manage Events

	  The admin can create new events, update event details, or delete events.
	  When creating a new event, the admin must provide event details (name, date, description, price, available seats).
	  Admin can also view all bookings for any event (who has booked, how many tickets, and user details).
 
3.	  Manage Bookings
   
	  Admin can view all user bookings across events.
	  Admin can also cancel bookings if necessary, and update availability if required (e.g., if an event gets sold out).

4.	Event Availability
   
	  Admin can set seat availability for each event.
	  If events are fully booked, the system will show them as Sold Out.

