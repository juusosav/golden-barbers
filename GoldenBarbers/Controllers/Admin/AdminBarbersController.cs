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
    public class AdminBarbersController : ControllerBase
    {
        private readonly AdminBarbersService _adminBarbersService;

        public AdminBarbersController(AdminBarbersService adminBarbersService)
        {
            _adminBarbersService = adminBarbersService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBarbers()
        {
            var barbers = await _adminBarbersService.GetAllBarbers();

            if (barbers == null)
            {
                return NotFound();
            }

            return Ok(barbers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AdminBarberDto>> GetBarberById(Guid id)
        {
            var barber = await _adminBarbersService.GetBarberById(id);

            if (barber == null)
            {
                return NotFound();
            }

            return Ok(barber);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBarberAsync(Guid id)
        {
            var deleted = await _adminBarbersService.DeleteBarberAsync(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditBarberAsync(Guid id, [FromBody] AdminBarberDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var updated = await _adminBarbersService.EditBarberAsync(id, dto);
            if (!updated)
                return NotFound();

            return NoContent();
        }
    }
}
