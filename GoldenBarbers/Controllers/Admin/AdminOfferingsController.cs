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
    }
}
