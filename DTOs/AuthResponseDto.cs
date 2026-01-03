using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Film.Models;

namespace Film.DTOs
{
    public class AuthResponseDto
    {
        public string Token { get; set; } = null!;
        public UserDto User { get; set; } = null!;
    }
}