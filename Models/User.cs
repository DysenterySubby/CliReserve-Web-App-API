using CliReserve.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CliReserve.Models
{
    public class User : IdentityUser
    {
        [Key]
        [Required]
        public int StudentNumber { get; set; }
        [Required]
        public string FirstName { get; set; } = null!;
        [Required]
        public string LastName { get; set; } = null!;
        public string? BookingId { get; set; }
        public Booking? Booking { get; set; }
    }
}
