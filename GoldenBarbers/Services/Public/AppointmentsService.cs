using GoldenBarbers.Data;
using GoldenBarbers.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.DTOs;

namespace GoldenBarbers.Services.Public
{
    public class AppointmentsService
    {
        private readonly ApplicationDbContext _context;
        private readonly PricingService _pricing;

        public AppointmentsService(ApplicationDbContext context, PricingService pricing)
        {
            _context = context;
            _pricing = pricing;
        }

        public async Task<List<TimeslotDto>> GetAvailableSlotsAsync(DateTime weekStart)
        {
            weekStart = DateTime.SpecifyKind(weekStart.Date, DateTimeKind.Utc);

            var weekEnd = weekStart.AddDays(7);

            var barbers = await _context.Barbers
                .Select(b => new BarberDto
                {
                    Id = b.Id,
                    Name = b.Name
                })
                .ToListAsync();

            var appointments = await _context.Appointments
                .Where(a => a.AppointmentDateTime >= weekStart && a.AppointmentDateTime < weekEnd)
                .Select(a => new AppointmentDto
                {
                    BarberId = a.BarberId,
                    AppointmentDateTime = a.AppointmentDateTime,
                    DurationMinutes = a.DurationMinutes,
                    OfferingName = a.OfferingName
                })
                .ToListAsync();

            var slots = new List<TimeslotDto>();

            foreach (var b in barbers)
            {
                for (int day = 0; day < 7; day++)
                {
                    var currentDate = weekStart.Date.AddDays(day);
                    var dayStart = currentDate.AddHours(9);
                    var dayEnd = currentDate.AddHours(17);

                    for (var current = dayStart; current < dayEnd; current = current.AddMinutes(30))
                    {
                        var occupied = appointments.Any(a =>
                        a.BarberId == b.Id &&
                        a.AppointmentDateTime <= current &&
                        current < a.AppointmentDateTime.AddMinutes(a.DurationMinutes)
                    );

                        slots.Add(new TimeslotDto
                        {
                            Id = Guid.NewGuid(),
                            BarberId = b.Id,
                            BarberName = b.Name,
                            Start = current,
                            Duration = 30,
                            IsAvailable = !occupied
                        });
                    }
                }
            }

            return slots;

        }

        public async Task<int> CalculateAppointmentPrice(Guid offeringId, int barberPositionId)
        {
            var offering = await _context.Offerings
                .FirstAsync(o => o.Id == offeringId);

            return _pricing.CalculatePrice(offering, barberPositionId);
        }

        public async Task<AppointmentDto?> GetByIdAsync(Guid id)
        {

            return await _context.Appointments
                .Where(a => a.Id == id)
                .Select(a => new AppointmentDto
                {
                    Id = a.Id,
                    BarberId = a.BarberId,
                    BarberName = a.BarberName,
                    OfferingId = a.OfferingId,
                    OfferingName = a.OfferingName,
                    BarberPositionId = a.BarberPositionId,
                    AppointmentDateTime = a.AppointmentDateTime,
                    DurationMinutes = a.DurationMinutes,
                    CustomerName = a.CustomerName,
                    CustomerEmail = a.CustomerEmail,
                    FinalPrice = a.FinalPrice
                })
                .FirstOrDefaultAsync();
        }

        public async Task<Appointment> CreateAppointmentAsync(AppointmentDto dto)
        {
            var offering = await _context.Offerings.FirstAsync(o => o.Id == dto.OfferingId);

            var price = _pricing.CalculatePrice(offering, dto.BarberPositionId);

            var appointment = new Appointment
            {
                Id = Guid.NewGuid(),
                BarberId = dto.BarberId,
                BarberName = dto.BarberName,
                BarberPositionId = dto.BarberPositionId,
                OfferingId = dto.OfferingId,
                OfferingName = dto.OfferingName,
                AppointmentDateTime = dto.AppointmentDateTime,
                DurationMinutes = dto.DurationMinutes,
                CustomerName = dto.CustomerName,
                CustomerEmail = dto.CustomerEmail,
                FinalPrice = price
            };

            _context.Appointments.Add(appointment);

            await _context.SaveChangesAsync();

            return appointment;
        }

    }
}
