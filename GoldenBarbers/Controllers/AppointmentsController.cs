using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GoldenBarbers.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GoldenBarbers.Models.Entities;
using Shared.DTOs;
using Microsoft.EntityFrameworkCore;

namespace GoldenBarbers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AppointmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("available-slots")]
        public async Task<ActionResult<List<TimeslotDto>>> GetAvailableSlotsAsync([FromQuery] DateTime weekStart)
        {
            weekStart = DateTime.SpecifyKind(weekStart.Date, DateTimeKind.Utc);

            if (weekStart == default)
            {
                return BadRequest("weekStart query parameter is required");
            }

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
                    DurationMinutes = a.DurationMinutes
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
    }
}
