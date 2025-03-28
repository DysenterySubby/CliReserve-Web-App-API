using System.ComponentModel.DataAnnotations;

namespace CliReserve.Entities
{
    public class SeatType
    {
        [Key]
        public string SeatTypeId { get; set; } = null!;
        public string TypeName { get; set; } = null!;
        public Clir Clir { get; set; } = null!;
        public List<Seat> Seats { get; set; } = [];
    }
}
