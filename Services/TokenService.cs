namespace CliReserve.Services
{
    using CliReserve.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Identity.Client;
    using Microsoft.IdentityModel.Tokens;
    using NuGet.Protocol;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;

    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;
        private readonly UserManager<User> _userManager;
        private readonly SymmetricSecurityKey _key;
        
        public TokenService(IConfiguration config, UserManager<User> userManager)
        {
            _config = config;
            _userManager = userManager;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("JWT:SigningKey").Value));
        }

        public string CreateToken(User user)
        {
            var securityToken = new JwtSecurityToken(
                issuer: _config.GetSection("JWT:Issuer").Value,
                audience: _config.GetSection("JWT:Audience").Value,
                claims: new List<Claim>
                    {
                        new Claim(JwtRegisteredClaimNames.Email, user.Email),
                        new Claim(ClaimTypes.Role, "User")
                    },
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: new SigningCredentials(_key, SecurityAlgorithms.HmacSha512));

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }

    public interface ITokenService
    {
        public string CreateToken(User user);
    }
}
