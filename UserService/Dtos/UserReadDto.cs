using System.ComponentModel.DataAnnotations;

namespace UserService.Dtos
{
    public class UserReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NIM { get; set; }
        public string Password { get; set; }
        public bool Role { get; set; }
    }
}
