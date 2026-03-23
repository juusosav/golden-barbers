using GoldenBarbers.Data;
using GoldenBarbers.Models.Entities;
using GoldenBarbers.Services.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.DTOs.Public;
using Shared.DTOs.Admin.Appointments;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoldenBarbers.Controllers.Admin
{
    [Route("api/admin/appointments")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminAppointmentController : ControllerBase
    {
        private readonly AdminAppointmentService _adminAppointmentService;

        public AdminAppointmentController(AdminAppointmentService adminAppointmentService)
        {
            _adminAppointmentService = adminAppointmentService;
        }


        [HttpGet]
        public async Task<ActionResult<List<AppointmentDto>>> GetAppointmentsAsync(
            [FromQuery] FilterDto filter)
        {
            var appointments = await _adminAppointmentService.GetFilteredAppointmentsAsync(filter);

            if (appointments == null)
            {
                return NotFound();
            }

            return Ok(appointments);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointmentAsync(Guid id)
        {
            var deleted = await _adminAppointmentService.DeleteAppointmentAsync(id);

            if (!deleted)
                return NotFound(); 

            return NoContent();
        }
    }
}
