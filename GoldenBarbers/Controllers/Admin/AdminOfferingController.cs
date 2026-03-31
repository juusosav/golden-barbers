using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using GoldenBarbers.Services.Admin;
using Shared.DTOs.Admin.Offerings;

namespace GoldenBarbers.Controllers.Admin
{
    [Route("api/admin/offerings")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminOfferingController : ControllerBase
    {
        private readonly AdminOfferingService _adminOfferingService;

        public AdminOfferingController(AdminOfferingService adminOfferingService)
        {
            _adminOfferingService = adminOfferingService;
        }

        [HttpGet]
        public async Task<ActionResult<List<AdminOfferingDto>>> GetOfferingsAsync()
        {
            var offerings = await _adminOfferingService.GetOfferingsAsync();

            if (offerings == null)
            {
                return NotFound();
            }

            return Ok(offerings);
        }

        [HttpGet("{id}")]
        [ActionName("GetOfferingById")]
        public async Task<ActionResult<AdminOfferingDto?>> GetOfferingByIdAsync(Guid id)
        {
            var offering = await _adminOfferingService.GetOfferingByIdAsync(id);

            if (offering == null)
                return NotFound();

            return Ok(offering);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOfferingAsync(Guid id)
        {
            var deleted = await _adminOfferingService.DeleteOfferingAsync(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditOfferingAsync(
            Guid id,
            [FromForm] AdminOfferingDto dto,
            [FromForm] IFormFile? file)
        {
            var updated = await _adminOfferingService.EditOfferingAsync(id, dto, file);

            if (!updated)
                return NotFound();

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult> CreateOfferingAsync(
            [FromForm] AdminOfferingDto dto,
            [FromForm] IFormFile file)
        {
            if (file != null)
            {
                var fileName = $"{Guid.NewGuid()}_{file.FileName}";
                var filePath = Path.Combine("wwwroot/images", fileName);

                using var stream = new FileStream(filePath, FileMode.Create);
                await file.CopyToAsync(stream);

                dto.Icon = $"images/{fileName}";
            }

            var created = await _adminOfferingService.CreateOfferingAsync(dto);

            if (created == null)
                return BadRequest();

            return CreatedAtAction(
                "GetOfferingById",
                new { id = created.Id },
                created
                );
        }
    }
}
