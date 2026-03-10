using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GoldenBarbers.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GoldenBarbers.Models.Entities;
using Shared.DTOs;
using Microsoft.EntityFrameworkCore;
using GoldenBarbers.Services.Admin;

namespace GoldenBarbers.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
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
