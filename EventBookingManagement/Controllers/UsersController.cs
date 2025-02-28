using EventManagementSystem.Data;
using EventManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using BCrypt.Net;
using Microsoft.AspNetCore.Mvc.ModelBinding;


namespace EventManagementSystem.Controllers
{
    public class UsersController:Controller
    {
        //dependency injection
        private readonly AppDbContext _context;
        public string hashpswd;
        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        //LoginPage
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Users users)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == users.Email);
            if (user == null)
            {
                return NotFound("Username or Password is incorrect");
            }
            bool isValidPassword = ValidateUser(users.Password, user.Password);
            if (isValidPassword)
            { 
                return RedirectToAction("ShowUsers" ,"Event");
            }
            else
            {
                ModelState.AddModelError("", "Invalid email or password.");
                return View("Create");
            }
        }

       //password verify
        public bool ValidateUser(string enteredPassword, string storedHashedPassword)
        {
             bool isValidPassword = BCrypt.Net.BCrypt.Verify(enteredPassword, storedHashedPassword);
             return isValidPassword;
        }


        // create Users
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Users users)
        {
          if(ModelState.IsValid)
            {
                hashpswd = BCrypt.Net.BCrypt.HashPassword(users.Password);
                users.Password = hashpswd;
                _context.Users.Add(users);
                _context.SaveChanges();
                return RedirectToAction("Print");
            }
          return RedirectToAction("Login");
        }

        //read
         public IActionResult Print()
        {
            var users=_context.Users.ToList();
            return View(users);
        }

    }
}
