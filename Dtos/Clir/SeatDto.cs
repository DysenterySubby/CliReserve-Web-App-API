namespace CliReserve.Dtos.Clir
{
    public class SeatDto
    {
        public string SeatId { get; set; } = null!;
        public string SeatTypeId { get; set; } = null!;
        public string TypeName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Capacity { get; set; }
        public int BookedCount { get; set; }
        public bool IsAvailable { get; set; }
    }
}
