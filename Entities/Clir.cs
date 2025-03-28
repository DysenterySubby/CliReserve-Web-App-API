using System.ComponentModel.DataAnnotations;

namespace CliReserve.Entities
{
    public class Clir
    {
        //[Key]
        //public int ClirId { get; set; }
        [Key]
        public string ClirName { get; set; } = null!;
        public string ClirLocation { get; set; } = null!;
        public List<SeatType> SeatTypes { get; set; } = [];
    }
}
