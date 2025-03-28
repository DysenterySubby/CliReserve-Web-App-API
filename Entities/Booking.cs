using CliReserve.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;

namespace CliReserve.Entities
{
    public class Booking
    {
        [Key]
        public string BookingId { get; set; } = null!;
        public DateTime BookingDate { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public int Duration { get; set; }
        public bool Approved { get; set; }
        public bool Finished { get; set; }
        public string UserId { get; set; } = null!;
        public User User { get; set; } = null!;
        public string SeatId { get; set; } = null!;
        public Seat Seat { get; set; } = null!;
    }
}
