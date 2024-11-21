using System.ComponentModel.DataAnnotations;

namespace UserService.Dtos
{
    public class UserCreateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string NIM { get; set; }
        [Required]
        [MinLength(8)]
        public string Password { get; set; }
        [Required]
        public bool Role { get; set; }
    }
}
