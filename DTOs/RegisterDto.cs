using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Film.DTOs
{
    public class RegisterDto
    {
        [Required, MaxLength(25)]
        public string UserName { get; set; } = null!;

        [Required, MaxLength(50)]
        public string Name { get; set; } = null!;

        [Required, EmailAddress, MaxLength(100)]
        public string Email { get; set; } = null!;

        [Required, MinLength(8)]
        public string Password { get; set; } = null!;
    }
}