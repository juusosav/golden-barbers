using GoldenBarbers.Data;
using GoldenBarbers.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Shared.DTOs;
using Shared.DTOs.Admin.Appointments;

namespace GoldenBarbers.Services.Admin
{
    public class AdminAppointmentsService
    {
        private readonly ApplicationDbContext _context;

        public AdminAppointmentsService(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<bool> DeleteAppointmentAsync(Guid id)
        {
            var appointmentToDelete = await _context.Appointments
                .FindAsync(id);

            if (appointmentToDelete == null)
                return false;

            _context.Appointments.Remove(appointmentToDelete);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<AppointmentDto>> GetFilteredAppointments(FilterDto filter)
        {
            var query = _context.Appointments
                .AsQueryable();

            // Filtering logic
            if (!string.IsNullOrWhiteSpace(filter.SearchTerm))
            {
                switch (filter.SearchBy.ToLower())
                {
                    case "customer":
                        query = query.Where(a =>
                            a.CustomerName.Contains(filter.SearchTerm));
                        break;

                    case "barber":
                        query = query.Where(a =>
                            a.BarberName.Contains(filter.SearchTerm));
                        break;

                    case "service":
                        query = query.Where(a =>
                            a.OfferingName.Contains(filter.SearchTerm));
                        break;
                }
            }

            // Sorting
            query = filter.SortBy?.ToLower() switch
            {
                "customer" => filter.SortByDescending
                    ? query.OrderByDescending(a => a.CustomerName)
                    : query.OrderBy(a => a.CustomerName),
                "barber" => filter.SortByDescending
                    ? query.OrderByDescending(b => b.BarberName)
                    : query.OrderBy(b => b.BarberName),
                _ => filter.SortByDescending
                    ? query.OrderByDescending(a => a.AppointmentDateTime)
                    : query.OrderBy(a => a.AppointmentDateTime)
            };

            // Pagination
            query = query
                .Skip((filter.Page - 1) * filter.PageSize)
                .Take(filter.PageSize);

            // Projection to DTO
            var appointments = await query
                .Select(a => new AppointmentDto
                {
                    Id = a.Id,
                    AppointmentDateTime = a.AppointmentDateTime,
                    DurationMinutes = a.DurationMinutes,
                    CustomerName = a.CustomerName,
                    CustomerEmail = a.CustomerEmail,
                    BarberName = a.BarberName,
                    OfferingName = a.OfferingName,
                    FinalPrice = a.FinalPrice
                })
                .ToListAsync();

            return appointments;
        }
    }
}
