using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingClient.Models
{
    public class BookingSlotDto : ErrorResponeDto
    {
        public int Id { get; set; }
        public DateTime BookingTime { get; set; }
        public string LaneName { get; set; }
    }
}

