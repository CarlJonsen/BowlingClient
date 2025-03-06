
namespace BowlingClient.Models
{
    public class MatchDto : ErrorResponeDto
    {
        public int Id { get; set; } 
        public string MatchName  { get; set; }
        public int AccountId { get; set; }
        public string WinnerName { get; set; }
        public int BookingSlotId { get; set; }
        public DateTime BookingTime { get; set; }
        public List<string> PlayerNames { get; set; }
    }
}
