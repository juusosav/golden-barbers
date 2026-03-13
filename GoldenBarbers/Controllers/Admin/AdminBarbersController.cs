using GoldenBarbers.Services.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
    }
}
