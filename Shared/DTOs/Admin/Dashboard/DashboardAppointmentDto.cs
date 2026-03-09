using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs.Admin.Dashboard
{
    public class DashboardAppointmentDto
    {
        public DateTime Time { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string OfferingName { get; set; } = string.Empty;
        public string BarberName { get; set; } = string.Empty;

    }
}
