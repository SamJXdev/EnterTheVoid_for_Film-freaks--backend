using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Film.Constants;

namespace Film.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Role { get; set; } = Roles.User;
    }
}