using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Film.DTOs;
using Film.Services;
using Microsoft.AspNetCore.Mvc;

namespace Film.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var user = await _authService.Register(
                dto.Name, dto.UserName, dto.Email, dto.Password
            );

            return Ok(new { message = "User registered successfully", user=new UserDto
            {
                Id = user.Id,
                UserName = user.UserName,
                Name = user.Name,
                Email = user.Email,
                Role = user.Role
            }
            });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var authResponse = await _authService.Login(dto.Email, dto.Password);
            return Ok(authResponse);
        }
    }
}