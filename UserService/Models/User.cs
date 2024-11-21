using System.ComponentModel.DataAnnotations;

namespace UserService.Models
{
    public class User
    {
        [Key]
        [Required]
        public int Id { get; set; }
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
