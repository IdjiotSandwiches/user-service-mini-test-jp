﻿using System.ComponentModel.DataAnnotations;

namespace UserService.Dtos
{
    public class UserReadDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string NIM { get; set; }
        public required string Password { get; set; }
        public required bool Role { get; set; }
    }
}
