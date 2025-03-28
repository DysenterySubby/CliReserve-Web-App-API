using CliReserve.Entities;
using System.ComponentModel.DataAnnotations;

namespace CliReserve.Dtos.Auth
{
    public class RegisterDto
    {
        [Required]
        public int StudentNumber { get; set; }
        [Required]
        
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
