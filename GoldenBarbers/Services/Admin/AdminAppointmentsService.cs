using GoldenBarbers.Data;
using Microsoft.EntityFrameworkCore;
using Shared.DTOs;

namespace GoldenBarbers.Services.Admin
{
    public class AdminAppointmentsService
    {
        private readonly ApplicationDbContext _context;

        public AdminAppointmentsService(ApplicationDbContext context)
        {
            _context = context; 
        }

        public async Task<IEnumerable<AppointmentDto?>> GetAllAppointments()
        {
            var appointments = await _context.Appointments
                .Select(o => new AppointmentDto
                {
                    Id = o.Id,
                    AppointmentDateTime = o.AppointmentDateTime,
                    DurationMinutes = o.DurationMinutes,
                    CustomerName = o.CustomerName,
                    CustomerEmail = o.CustomerEmail,
                    BarberName = o.BarberName,
                    OfferingName = o.OfferingName,
                    FinalPrice = o.FinalPrice
                })
                .ToListAsync();

            return appointments;
        }
    }
}
