using GoldenBarbers.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.DTOs.Admin.Dashboard;

namespace GoldenBarbers.Services.Admin
{
    public class AdminDashboardService
    {
        private readonly ApplicationDbContext _context;

        public AdminDashboardService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<AdminDashboardDto?> GetDashboardAsync()
        {
            var today = DateTime.UtcNow.Date;
            var tomorrow = today.AddDays(1);
            var nextWeek = today.AddDays(7);

            var appointmentsToday = await _context.Appointments
                .CountAsync(a => a.AppointmentDateTime == today && a.AppointmentDateTime < tomorrow);

            var upcomingWeek = await _context.Appointments
                .CountAsync(a => a.AppointmentDateTime >= today && a.AppointmentDateTime <= nextWeek);

            var revenueToday = (decimal?)(await _context.Appointments
                .Where(a => a.AppointmentDateTime == today && a.AppointmentDateTime < tomorrow)
                .SumAsync(a => (double?)a.FinalPrice) ?? 0);

            // TODO: Implement schedule for today
            var todaySchedule = await _context.Appointments
                .Where(a => a.AppointmentDateTime == today && a.AppointmentDateTime < tomorrow)
                .OrderBy(a => a.AppointmentDateTime)
                .Select(a => new AdminDashboardAppointmentDto
                {
                    Time = a.AppointmentDateTime,
                    CustomerName = a.CustomerName
                })
                .ToListAsync();

            return new AdminDashboardDto
            {
                AppointmentsToday = appointmentsToday,
                UpcomingWeek = upcomingWeek,
                TodaySchedule = todaySchedule,
                RevenueToday = revenueToday
            };
        }
    }
}

