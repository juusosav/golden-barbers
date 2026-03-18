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
        public async Task<IActionResult> EditOffering(Guid id, [FromBody] AdminOfferingDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var updated = await _adminOfferingsService.EditOffering(id, dto);

            if (!updated)
                return NotFound();

            return NoContent();
        }
    }
}
