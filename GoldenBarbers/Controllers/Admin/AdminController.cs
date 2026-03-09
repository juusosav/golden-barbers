using Microsoft.AspNetCore.Mvc;
using GoldenBarbers.Data;
using Shared.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Shared.DTOs.Admin.Dashboard;
using GoldenBarbers.Services.Admin;

namespace GoldenBarbers.Controllers.Admin
{

    [Route("api/admin")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminController : ControllerBase
    {
        private readonly DashboardService _dashboardService;

        public AdminController(DashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        [HttpGet("dashboard")]
        public async Task<ActionResult<DashboardDto?>> GetDashboard()
        {
            var dashboard = await _dashboardService.GetDashboard();

            if (dashboard == null)
            {
                return NotFound();
            }

            return Ok(dashboard);
        }
    }
}
