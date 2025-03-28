using CliReserve.Entities;

namespace CliReserve.Dtos.Clir
{
    public class QrScanDto
    {
        public string SeatId { get; set; } = null!;
        public IEnumerable<SeatDto> Seats { get; set; } = [];
        public IEnumerable<SeatTypeDto> SeatTypes { get; set; } = [];
    }
}
