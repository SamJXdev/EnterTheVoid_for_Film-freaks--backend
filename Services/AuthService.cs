using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Film.DTOs;

using Film.Models;
using Film.Data;
using Microsoft.EntityFrameworkCore;

namespace Film.Services
{
    public class AuthService
    {
        private readonly AppDbContext _context;
        private readonly JwtService _jwtService;

        public AuthService(AppDbContext context, JwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }

        public async Task<User> Register(string name, string username, string email, string password)
        {
            if(await _context.Users.AnyAsync(u => u.Email==email))
            {
                throw new ArgumentException("Email already in use");
            }
            if(await _context.Users.AnyAsync(u=>u.UserName==username))
            {
                throw new ArgumentException("Username already taken");
            }

            PasswordValidator(password);

            var hashed = BCrypt.Net.BCrypt.HashPassword(password);

            var user = new User
            {
                Name = name,
                UserName = username,
                Email = email,
                PasswordHash = hashed
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        private void PasswordValidator(string password)
        {
            if (password.Length < 8)
            {
                throw new ArgumentException("Password must have atleast 8 characters");
            }
            if (!password.Any(char.IsUpper))
            {
                throw new ArgumentException("Password must contain an uppercase letter");
            }
            if (!password.Any(char.IsLower))
            {
                throw new ArgumentException("Password must contain an lowercase letter");
            }
            if(!password.Any(ch => !char.IsLetterOrDigit(ch)))
            {
                throw new ArgumentException("Password must contain an symbol");
            }
        }

        public async Task<AuthResponseDto> Login(string email, string password)
        {
            var user = await _context.Users.AsNoTracking().FirstOrDefaultAsync(u=>u.Email==email);

            if (user == null)
            {
                throw new UnauthorizedAccessException("Invalid email or password");
            }

            if(!BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                throw new UnauthorizedAccessException("Invalid email or password");
            }
            var token = _jwtService.GenerateToken(user);

            var userDto = new UserDto
            {
                Id = user.Id,
                UserName = user.UserName,
                Name = user.Name,
                Email = user.Email,
                Role = user.Role
            };

            return new AuthResponseDto
            {
                Token = token,
                User = userDto
            };
        }
    }
}