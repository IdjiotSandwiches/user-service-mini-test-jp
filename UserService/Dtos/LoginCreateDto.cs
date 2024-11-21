using System.ComponentModel.DataAnnotations;

namespace UserService.Dtos
{
    public class LoginCreateDto
    {
        [Required]
        public required string NIM { get; set; }
        [Required]
        public required string Password { get; set; }
    }
}
