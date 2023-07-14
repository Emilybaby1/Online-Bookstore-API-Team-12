using System.ComponentModel.DataAnnotations;

namespace BookStore__Management_system.Models
{
    public class RegisterModel
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string ConfirmedPassword { get; set; }
    }
}
