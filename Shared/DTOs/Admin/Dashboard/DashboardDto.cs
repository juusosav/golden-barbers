using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs.Admin.Dashboard
{
    public class DashboardDto
    {
        public int AppointmentsToday { get; set; }
        public int UpcomingWeek { get; set; }
        public decimal RevenueToday { get; set; }
        public int ActiveBarbers { get; set; }

        public List<DashboardAppointmentDto> TodaySchedule { get; set; } = [];
    }
}
