using GoldenBarbers.Data;
using GoldenBarbers.Models.Entities;
using GoldenBarbers.Services.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.DTOs;
using Shared.DTOs.Admin.Appointments;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoldenBarbers.Controllers.Admin
{
    [Route("api/admin/appointments")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminAppointmentsController : ControllerBase
    {
        private readonly AdminAppointmentsService _adminAppointmentsService;

        public AdminAppointmentsController(AdminAppointmentsService adminAppointmentsService)
        {
            _adminAppointmentsService = adminAppointmentsService;
        }


        [HttpGet]
        public async Task<ActionResult<List<AppointmentDto>>> GetAppointments(
            [FromQuery] FilterDto filter)
        {
            var appointments = await _adminAppointmentsService.GetFilteredAppointments(filter);

            if (appointments == null)
            {
                return NotFound();
            }

            return Ok(appointments);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointmentAsync(Guid id)
        {
            var deleted = await _adminAppointmentsService.DeleteAppointmentAsync(id);

            if (!deleted)
                return NotFound(); 

            return NoContent();
        }
    }
}
