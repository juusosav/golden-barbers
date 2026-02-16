using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs
{
    public class OfferingDto
    {
        
        public Guid Id { get; set; }

        public string Name { get; set; } = "";

        public TimeSpan Timeslot { get; set; }

        public double Rate { get; set; }

        public int AppointmentId { get; set; }
    }
}
