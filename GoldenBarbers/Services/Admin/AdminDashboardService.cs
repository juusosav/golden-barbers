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
            var nextWeek = today.AddDays(7);

            var appointmentsToday = await _context.Appointments
                .CountAsync(a => a.AppointmentDateTime.Date == today);

            var upcomingWeek = await _context.Appointments
                .CountAsync(a => a.AppointmentDateTime.Date >= today && a.AppointmentDateTime.Date <= nextWeek);

            var revenueToday = await _context.Appointments
                .Where(a => a.AppointmentDateTime.Date == today)
                .SumAsync(a => a.FinalPrice);

            var todaySchedule = await _context.Appointments
                .Where(a => a.AppointmentDateTime.Date == today)
                .OrderBy(a => a.AppointmentDateTime)
                .Select(a => new AdminDashboardAppointmentDto
                {
                    Time = a.AppointmentDateTime,
                    CustomerName = a.CustomerName
                    // Add offering name
                    // Add barber name
                })
                .ToListAsync();

            var dto = new AdminDashboardDto
            {
                AppointmentsToday = appointmentsToday,
                UpcomingWeek = upcomingWeek,
                TodaySchedule = todaySchedule,
                RevenueToday = revenueToday
            };

            return dto;
        }
    }
}
