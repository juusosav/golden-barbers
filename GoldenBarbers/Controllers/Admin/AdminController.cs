using Microsoft.AspNetCore.Mvc;
using GoldenBarbers.Data;
using Shared.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Shared.DTOs.Admin.Dashboard;

namespace GoldenBarbers.Controllers.Admin
{

    [Route("api/admin")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context; 
        }

        [HttpGet("dashboard")]
        public async Task<IActionResult> GetDashboard()
        {
            var today = DateTime.UtcNow.Date;
            var nextWeek = today.AddDays(7);

            var appointmentsToday = await _context.Appointments
                .CountAsync(a => a.AppointmentDateTime.Date == today);

            var upcomingWeek = await _context.Appointments
                .CountAsync(a => a.AppointmentDateTime.Date >= today && a.AppointmentDateTime.Date <= nextWeek);

            /* Add revenue today, have to think about how to add the price of
            the service to the Appointment model. 
            Currently it lives in Appointment.razor, move to backend? */

            var todaySchedule = await _context.Appointments
                .Where(a => a.AppointmentDateTime.Date == today)
                .OrderBy(a => a.AppointmentDateTime)
                .Select(a => new DashboardAppointmentDto
                {
                    Time = a.AppointmentDateTime,
                    CustomerName = a.CustomerName
                    // Add offering name
                    // Add barber name
                })
                .ToListAsync();

            var response = new DashboardDto 
            {
                AppointmentsToday = appointmentsToday,
                UpcomingWeek = upcomingWeek,
                TodaySchedule = todaySchedule
            };



            return Ok(response);
        }
    }
}
