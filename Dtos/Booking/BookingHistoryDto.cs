namespace CliReserve.Dtos.Booking
{
    public class BookingHistoryDto
    {
        public DateTime BookingDate { get; set; }
        public List<BookingHistoryData> Bookings { get; set; }
    }

    public class BookingHistoryData
    {
        public string BookingId { get; set; } = null!;
        public string SeatId { get; set; } = null!;
        public string TypeName { get; set; } = null!;
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        
    }
}
