using GoldenBarbers.Data;
using GoldenBarbers.Models.Entities;
using GoldenBarbers.Services.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoldenBarbers.Controllers.Admin
{
    [Route("api/[controller]")]
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
        public async Task<ActionResult<IEnumerable<AppointmentDto?>>> GetAllAppointments()
        {
            var appointments = await _adminAppointmentsService.GetAllAppointments();

            if (appointments == null)
            {
                return NotFound();
            }

            return Ok(appointments);
        }
    }
}
