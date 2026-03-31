using Microsoft.AspNetCore.Mvc;
using Shared.DTOs.Public;
using GoldenBarbers.Services.Public;

namespace GoldenBarbers.Controllers.Public
{
    [Route("api/appointments")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly AppointmentService _appointmentService;

        public AppointmentController(AppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet("available-slots")]
        public async Task<ActionResult<List<TimeslotDto>>> GetAvailableSlotsAsync(
            [FromQuery] DateTime weekStart)
        {
            if (weekStart == default)
            {
                return BadRequest("weekStart query parameter is required.");
            }

            var slots = await _appointmentService.GetAvailableSlotsAsync(weekStart);

            return Ok(slots);
        }

        [HttpGet("{id}")]
        [ActionName("GetById")]
        public async Task<ActionResult<AppointmentDto>> GetByIdAsync(Guid id)
        {
            var appointment = await _appointmentService.GetByIdAsync(id);

            if (appointment == null)
            {
                return NotFound();
            }

            return Ok(appointment);
        }

        [HttpPost]
        public async Task<ActionResult> CreateAppointmentAsync(
            [FromBody] AppointmentDto dto)
        {
            var appointment = await _appointmentService.CreateAppointmentAsync(dto);

            if (appointment == null)
                return NotFound();

            return CreatedAtAction
                ("GetById",
                new { id = appointment.Id },
                appointment);
        }
    }
}
