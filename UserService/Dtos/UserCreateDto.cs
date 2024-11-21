using System.ComponentModel.DataAnnotations;

namespace UserService.Dtos
{
    public class UserCreateDto
    {
        [Required]
        public required string Name { get; set; }
        [Required]
        public required string NIM { get; set; }
        [Required]
        [MinLength(8)]
        public required string Password { get; set; }
        [Required]
        public bool Role { get; set; }
    }
}
