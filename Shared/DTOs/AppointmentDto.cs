using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs
{
    public class AppointmentDto
    {
        public Guid BarberId { get; set; }

        public Guid OfferingId { get; set; }

        public DateTime AppointmentDateTime { get; set; }

        public int DurationMinutes { get; set; }

        public string CustomerName { get; set; } = "";

        public string CustomerEmail { get; set; } = "";
    }
}
