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

            Console.WriteLine($"{today} found.");

            var prevMonthStart = new DateTime(today.Year, today.Month, 1, 0, 0, 0, DateTimeKind.Utc).AddMonths(-1);
            var prevMonthEnd = new DateTime(today.Year, today.Month, 1, 0, 0, 0, DateTimeKind.Utc).AddDays(-1);

            var thisMonthStart = new DateTime(today.Year, today.Month, 1, 0, 0, 0, DateTimeKind.Utc);
            var thisMonthEnd = thisMonthStart.AddMonths(1);

            Console.WriteLine("Start of previous month: " + prevMonthStart.ToString("yyyy-MM-dd"));
            Console.WriteLine("End of previous month: " + prevMonthEnd.ToString("yyyy-MM-dd"));

            var lastMonthAppointments = await _context.Appointments
                .CountAsync(a => a.AppointmentDateTime >= prevMonthStart
                && a.AppointmentDateTime <= prevMonthEnd);

            Console.WriteLine($"Amount of appointments last month: {lastMonthAppointments}");

            var lastMonthRevenue = await _context.Appointments
                .Where(a => a.AppointmentDateTime >= prevMonthStart
                && a.AppointmentDateTime <= prevMonthEnd)
                .SumAsync(a => a.FinalPrice);

            Console.WriteLine($"Revenue last month: {lastMonthRevenue}");

            var thisMonthAppointments = await _context.Appointments
                .CountAsync(a => a.AppointmentDateTime >= thisMonthStart
                && a.AppointmentDateTime <= thisMonthEnd);

            Console.WriteLine($"Amount of appointments this month: {thisMonthAppointments}");

            var thisMonthRevenue = await _context.Appointments
                .Where(a => a.AppointmentDateTime >= thisMonthStart
                && a.AppointmentDateTime <= thisMonthEnd)
                .SumAsync(a => a.FinalPrice);

            Console.WriteLine($"Revenue this month: {thisMonthRevenue}");

            var revenueChangeCount = lastMonthRevenue == 0 ? (decimal?)null 
                : (thisMonthRevenue - lastMonthRevenue) / lastMonthRevenue * 100;

            var appointmentsChangeCount = lastMonthAppointments == 0 ? (decimal?)null
                : (thisMonthAppointments - lastMonthAppointments) / lastMonthAppointments * 100;

            var dto = new AdminMetricDto
            {
                AppointmentsChangeCount = appointmentsChangeCount,
                RevenueChangeCount = revenueChangeCount
            };

            return dto;
        }
    }
}
