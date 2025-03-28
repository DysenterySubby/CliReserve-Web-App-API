using Azure;
using CliReserve.Dtos.Auth;
using CliReserve.Entities;
using CliReserve.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CliReserve.Services
{
    public interface IAuthService
    {

        Task<IActionResult?> Login(LoginDto loginDto);
        Task<IActionResult> Register(RegisterDto registerDto);
        Task<IActionResult> GetUser();
    }

    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AuthService(UserManager<User> userManager, SignInManager<User> signInManager, ITokenService tokenService, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IActionResult> GetUser()
        {
            var currentUser = await _userManager.FindByEmailAsync(_httpContextAccessor.HttpContext!.User.FindFirst(ClaimTypes.Email)!.Value);
            return new ObjectResult(new UserDto
            {
                Email = currentUser.Email,
                StudentNumber = currentUser.StudentNumber,
                FirstName = currentUser.FirstName,
                LastName = currentUser.LastName
            }) { StatusCode = 200 };
        }

        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == loginDto.Email);
            if (user != null)
            {
                var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
                if (result.Succeeded)
                {
                    return new ObjectResult(new ResponseDto
                           {
                                User = new UserDto
                                {
                                    StudentNumber = user.StudentNumber,
                                    Email = user.Email,
                                    FirstName = user.FirstName,
                                    LastName = user.LastName,
                                },
                                Token = _tokenService.CreateToken(user)
                           })
                    { StatusCode = 200 };
                }
            }
                    
            return new ObjectResult("Invalid Login Credentials") { StatusCode = 500 };
        }

        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            try
            {
                var user = new User
                {
                    UserName = registerDto.Email,
                    StudentNumber = registerDto.StudentNumber,
                    FirstName = registerDto.FirstName,
                    LastName = registerDto.LastName,
                    Email = registerDto.Email
                };
                var createdUser = await _userManager.CreateAsync(user, registerDto.Password);
                if (createdUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(user, "User");
                    if (roleResult.Succeeded)
                    {
                        return new ObjectResult (new ResponseDto
                        {
                            User = new UserDto
                            {
                                StudentNumber = user.StudentNumber,
                                Email = user.Email,
                                FirstName = user.FirstName,
                                LastName = user.LastName
                            },
                            Token = _tokenService.CreateToken(user)
                        }) { StatusCode = 200 };
                    }
                    return new ObjectResult(roleResult.Errors){ StatusCode = 500 };
                }
                return new ObjectResult(createdUser.Errors){ StatusCode = 500 };
            }
            catch (Exception e)
            {
                return new ObjectResult(e){ StatusCode = 500 };
            }
        }
        
    }
}
