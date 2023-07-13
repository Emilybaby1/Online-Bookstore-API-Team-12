using System.ComponentModel.DataAnnotations;

namespace BookStore__Management_system.Models
{
    public class UserChangeRoleModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Role { get; set; }
    }
}
