using GoldenBarbers.Data;
using Shared.DTOs.Admin.Metrics;
using Microsoft.EntityFrameworkCore;

namespace GoldenBarbers.Services.Admin
{
    public class AdminMetricService
    {
        private readonly ApplicationDbContext _context;

        public AdminMetricService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<AdminMetricDto?> GetMetricsAsync()
        {
            var today = DateTime.UtcNow.Date;
            var prevMonthStart = new DateTime(today.Year, today.Month, 1, 0, 0, 0, DateTimeKind.Utc).AddMonths(-1);
            var thisMonthStart = new DateTime(today.Year, today.Month, 1, 0, 0, 0, DateTimeKind.Utc);
            var thisMonthEnd = thisMonthStart.AddMonths(1);

            // Dashboard specific items
            var lastMonthAppointments = await _context.Appointments
                .CountAsync(a => a.AppointmentDateTime >= prevMonthStart
                && a.AppointmentDateTime < thisMonthStart);

            var lastMonthRevenue = (decimal?)(await _context.Appointments
                .Where(a => a.AppointmentDateTime >= prevMonthStart
                && a.AppointmentDateTime < thisMonthStart)
                .SumAsync(a => (double?)a.FinalPrice) ?? 0);

            var thisMonthAppointments = await _context.Appointments
                .CountAsync(a => a.AppointmentDateTime >= thisMonthStart
                && a.AppointmentDateTime < thisMonthEnd);

            var thisMonthRevenue = (decimal?)(await _context.Appointments
                .Where(a => a.AppointmentDateTime >= thisMonthStart
                && a.AppointmentDateTime < thisMonthEnd)
                .SumAsync(a => (double?)a.FinalPrice) ?? 0);

            var revenueChangeCount = lastMonthRevenue == 0 ? (decimal?)null 
                : (thisMonthRevenue - lastMonthRevenue) / lastMonthRevenue * 100;

            var appointmentsChangeCount = lastMonthAppointments == 0 ? (decimal?)null
                : (thisMonthAppointments - lastMonthAppointments) / lastMonthAppointments * 100;

            // Metric page specific items
            var monthLabels = new List<string>();
            var monthlyRevenue = new List<double>();
            var monthlyAppointments = new List<int>();

            for (int i = 5; i >= 0; i--)
            {
                var monthStart = new DateTime(today.Year, today.Month, 1, 0, 0, 0, DateTimeKind.Utc).AddMonths(-i);
                var monthEnd = monthStart.AddMonths(1);

                var revenue = (double)(await _context.Appointments
                        .Where(a => a.AppointmentDateTime >= monthStart && a.AppointmentDateTime < monthEnd)
                        .SumAsync(a => (double?)a.FinalPrice ?? 0));

                var count = await _context.Appointments
                    .CountAsync(a => a.AppointmentDateTime >= monthStart && a.AppointmentDateTime < monthEnd);

                monthLabels.Add(monthStart.ToString("MMM yyyy"));
                monthlyRevenue.Add(revenue);
                monthlyAppointments.Add(count);
            }

            var dto = new AdminMetricDto
            {
                AppointmentsChangeCount = appointmentsChangeCount,
                RevenueChangeCount = revenueChangeCount,
                MonthLabels = monthLabels,
                MonthlyRevenue = monthlyRevenue,
                MonthlyAppointments = monthlyAppointments
            };

            return dto;
        }
    }
}
