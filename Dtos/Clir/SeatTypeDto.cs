namespace CliReserve.Dtos.Clir
{
    public class SeatTypeDto
    {
        public string SeatTypeId { get; set; } = null!;
        public string TypeName { get; set; } = null!;
        public string ClirName { get; set; } = null!;
        public int SeatCount { get; set; }
    }
}
