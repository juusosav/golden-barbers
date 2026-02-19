using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs
{
    public class TimeslotDto
    {
        public Guid Id { get; set; }
        public DateTime Start { get; set; }

        public DateTime End => Start.AddMinutes(Duration); 

        public int Duration { get; set; } = 30;

        public Guid BarberId { get; set; }

        public string BarberName { get; set; } = "";

        public bool IsAvailable { get; set; }

    }
}
