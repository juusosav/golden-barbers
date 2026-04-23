using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs.Admin.Metrics
{
    public class AdminMetricDto
    {
        public decimal? AppointmentsChangeCount { get; set; }
        public decimal? RevenueChangeCount { get; set; }

        public List<string> MonthLabels { get; set; } = new();

        public List<double> MonthlyRevenue { get; set; } = new();

        public List<int> MonthlyAppointments { get; set; } = new();
    }
}
