using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GoldenBarbers.Data;
using GoldenBarbers.Models.Entities;
using Shared.DTOs.Public;
using GoldenBarbers.Services.Public;

namespace GoldenBarbers.Controllers.Public
{
    [Route("api/barbers")]
    [ApiController]
    public class BarberController : ControllerBase
    {
        private readonly BarberService _barberService;

        public BarberController(BarberService barberService)
        {
            _barberService = barberService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BarberDto>>> GetAllBarbersAsync()
        {
            var barbers = await _barberService.GetAllBarbersAsync();

            if (barbers == null)
            {
                return NotFound();
            }

            return Ok(barbers);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<BarberDto>> GetBarberByIdAsync(Guid id)
        {
            var barber = await _barberService.GetBarberByIdAsync(id);

            if (barber == null)
            {
                return NotFound();
            }
            return Ok(barber);
        }
    }
}
