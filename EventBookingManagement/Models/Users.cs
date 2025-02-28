using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EventManagementSystem.Models
{
    public class Users
    {
        [Key]
        public int Id {  get; set; }
        
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name cannot be larger than 50")]
        public string Name {  get; set; }

        [Required(ErrorMessage = "EmailId is required")]
        [StringLength(50, ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(150, ErrorMessage = "Password should be strong")]
        public string Password { get; set; }

    }
}
