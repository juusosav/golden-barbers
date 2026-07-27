using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs.Admin.Dashboard
{
    public class AdminDashboardAppointmentDto
    {
        public DateTime Time { get; set; }
        public string CustomerName { get; set; } = "";
        public string OfferingNameEn { get; set; } = "";
        public string OfferingNameFi { get; set; } = "";
        public string BarberName { get; set; } = "";

    }
}
