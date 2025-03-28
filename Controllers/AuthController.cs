using CliReserve.Data;
using CliReserve.Dtos.Auth;
using CliReserve.Entities;
using CliReserve.Models;
using CliReserve.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;

namespace CliReserve.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (ModelState.IsValid)
                return await _authService.Login(loginDto);
            return Unauthorized("Invalid Login Credintials");
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            if (ModelState.IsValid)
                return await _authService.Register(registerDto);
            return BadRequest(ModelState);
        }
        [Authorize(Roles = "User")]
        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            return await _authService.GetUser();
        }
    }
}
