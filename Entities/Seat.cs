using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CliReserve.Entities
{
    public class Seat
    {
        [Key]
        public string SeatId { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Capacity { get; set; }
        public bool IsAvailable { get; set; }
        public string SeatTypeId { get; set; } = null!;
        public SeatType SeatType { get; set; } = null!;
        public List<Booking> Bookings { get; set; } = [];
    }
}
