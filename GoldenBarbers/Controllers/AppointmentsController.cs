using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GoldenBarbers.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GoldenBarbers.Models.Entities;
using Shared.DTOs;
using Microsoft.EntityFrameworkCore;
using GoldenBarbers.Services.Public;

namespace GoldenBarbers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly AppointmentsService _appointmentsService;

        public AppointmentsController(AppointmentsService appointmentsService)
        {
            _appointmentsService = appointmentsService;
        }

        [HttpGet("available-slots")]
        public async Task<ActionResult<List<TimeslotDto>>> GetAvailableSlotsAsync([FromQuery] DateTime weekStart)
        {
           if (weekStart == default)
            {
                return BadRequest("weekStart query parameter is required.");
            }

            var slots = await _appointmentsService.GetAvailableSlotsAsync(weekStart);

            return Ok(slots);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppointmentDto>> GetByIdAsync(Guid id)
        {
            var appointment = await _appointmentsService.GetByIdAsync(id);

            if (appointment == null)
            {
                return NotFound();
            }

            return Ok(appointment);
        }

        [HttpPost]
        public async Task<ActionResult> CreateAppointmentAsync([FromBody] AppointmentDto dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }

            var appointment = await _appointmentsService.CreateAppointmentAsync(dto);

            return Ok(appointment);
        }
    }
}
