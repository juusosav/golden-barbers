using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Shared.DTOs.Admin.Dashboard;
using GoldenBarbers.Services.Admin;
using GoldenBarbers.Services.Admin.Interfaces;

namespace GoldenBarbers.Controllers.Admin
{

    [Route("api/admin")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminDashboardController : ControllerBase
    {
        private readonly IAdminDashboardService _dashboardService;

        public AdminDashboardController(IAdminDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        [HttpGet("dashboard")]
        public async Task<ActionResult<AdminDashboardDto?>> GetDashboardAsync()
        {
            var dashboard = await _dashboardService.GetDashboardAsync();

            if (dashboard == null)
            {
                return NotFound();
            }

            return Ok(dashboard);
        }
    }
}
