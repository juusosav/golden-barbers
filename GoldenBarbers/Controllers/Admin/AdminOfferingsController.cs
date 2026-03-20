using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using GoldenBarbers.Services.Admin;
using Shared.DTOs.Admin.Offerings;

namespace GoldenBarbers.Controllers.Admin
{
    [Route("api/admin/offerings")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminOfferingsController : ControllerBase
    {
        private readonly AdminOfferingsService _adminOfferingsService;

        public AdminOfferingsController(AdminOfferingsService adminOfferingsService)
        {
            _adminOfferingsService = adminOfferingsService;
        }

        [HttpGet]
        public async Task<ActionResult<List<AdminOfferingDto>>> GetOfferings()
        {
            var offerings = await _adminOfferingsService.GetOfferings();

            if (offerings == null)
            {
                return NotFound();
            }

            return Ok(offerings);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AdminOfferingDto?>> GetOfferingById(Guid id)
        {
            var offering = await _adminOfferingsService.GetOfferingById(id);

            if (offering == null)
                return NotFound();

            return Ok(offering);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOffering(Guid id)
        {
            var deleted = await _adminOfferingsService.DeleteOffering(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditOffering(
            Guid id, 
            [FromForm] AdminOfferingDto dto, 
            [FromForm] IFormFile? file)
        {
            var updated = await _adminOfferingsService.EditOffering(id, dto, file);

            if (!updated)
                return NotFound();

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult> CreateOffering([FromForm] AdminOfferingDto dto, [FromForm] IFormFile file)
        {
            if (file != null)
            {
                var fileName = $"{Guid.NewGuid()}_{file.FileName}";
                var filePath = Path.Combine("wwwroot/images", fileName);

                using var stream = new FileStream(filePath, FileMode.Create);
                await file.CopyToAsync(stream);

                dto.Icon = $"images/{fileName}";
            }

            var created = await _adminOfferingsService.CreateOffering(dto);

            if (created == null)
                return BadRequest();

            return CreatedAtAction(
                nameof(GetOfferingById),
                new { id = created.Id },
                created
                );
        }
    }
}
