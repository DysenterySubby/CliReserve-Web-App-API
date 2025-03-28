namespace CliReserve.Dtos.Booking
{
    public class BookingDto
    {
        public string BookingId { get; set; } = null!;
        public DateTime BookingDate { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public bool Approved { get; set; }
        public string SeatId { get; set; } = null!;
    }
}
