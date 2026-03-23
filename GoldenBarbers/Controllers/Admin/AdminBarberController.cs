using GoldenBarbers.Services.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;
using Shared.DTOs.Admin.Barbers;

namespace GoldenBarbers.Controllers.Admin
{
    [Route("api/admin/barbers")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminBarberController : ControllerBase
    {
        private readonly AdminBarberService _adminBarberService;

        public AdminBarberController(AdminBarberService adminBarberService)
        {
            _adminBarberService = adminBarberService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBarbersAsync()
        {
            var barbers = await _adminBarberService.GetAllBarbersAsync();

            if (barbers == null)
            {
                return NotFound();
            }

            return Ok(barbers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AdminBarberDto>> GetBarberByIdAsync(Guid id)
        {
            var barber = await _adminBarberService.GetBarberByIdAsync(id);

            if (barber == null)
            {
                return NotFound();
            }

            return Ok(barber);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBarberAsync(Guid id)
        {
            var deleted = await _adminBarberService.DeleteBarberAsync(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditBarberAsync(
            Guid id,
            [FromForm] AdminBarberDto dto,
            [FromForm] IFormFile? file)
        {
            var updated = await _adminBarberService.EditBarberAsync(id, dto, file);

            if (!updated)
                return NotFound();

            return NoContent();
        }
    }
}
