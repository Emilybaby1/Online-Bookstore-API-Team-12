using System.ComponentModel.DataAnnotations;

namespace BookStore__Management_system.Models
{
    public class LoginModel
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
