using System.ComponentModel.DataAnnotations;

namespace CliReserve.Dtos.Auth
{
    public class UserDto
    {
        public int StudentNumber { get; set; }
        public string Email { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
    }
}
