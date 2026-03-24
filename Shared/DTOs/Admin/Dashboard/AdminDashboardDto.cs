using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs.Admin.Dashboard
{
    public class AdminDashboardDto
    {
        public int AppointmentsToday { get; set; }
        public int UpcomingWeek { get; set; }
        public decimal RevenueToday { get; set; }

        public List<AdminDashboardAppointmentDto> TodaySchedule { get; set; } = [];
    }
}
