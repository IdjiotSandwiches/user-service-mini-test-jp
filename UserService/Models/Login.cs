using System.ComponentModel.DataAnnotations;

namespace UserService.Models
{
    public class Login
    {
        [Required]
        public required string NIM { get; set; }
        [Required]
        public required string Password { get; set; }
    }
}
