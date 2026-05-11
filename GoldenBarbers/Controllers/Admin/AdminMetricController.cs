using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Shared.DTOs.Admin.Dashboard;
using GoldenBarbers.Services.Admin;
using Shared.DTOs.Admin.Metrics;
using GoldenBarbers.Services.Admin.Interfaces;

namespace GoldenBarbers.Controllers.Admin
{
    [Route("api/admin")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminMetricController : ControllerBase
    {
        private readonly IAdminMetricService _metricService;

        public AdminMetricController(IAdminMetricService metricService)
        {
            _metricService = metricService;
        }

        [HttpGet("metrics")]
        public async Task<ActionResult<AdminMetricDto?>> GetMetricsAsync()
        {
            var metrics = await _metricService.GetMetricsAsync();

            if (metrics == null)
                return NotFound();

            return Ok(metrics);
        }
    }
}
