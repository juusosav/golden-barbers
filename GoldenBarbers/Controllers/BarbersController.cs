using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GoldenBarbers.Data;
using GoldenBarbers.Models.Entities;
using Shared.DTOs;
using GoldenBarbers.Services.Public;

namespace GoldenBarbers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarbersController : ControllerBase
    {
        private readonly BarbersService _barbersService;

        public BarbersController(BarbersService barbersService)
        {
            _barbersService = barbersService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BarberDto>>> GetAllBarbers()
        {
            var barbers = await _barbersService.GetAllBarbers();

            if (barbers == null)
            {
                return NotFound();
            }

            return Ok(barbers);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<BarberDto>> GetBarberById(Guid id)
        {
            var barber = await _barbersService.GetBarberById(id);

            if (barber == null)
            {
                return NotFound();
            }
            return Ok(barber);
        }
    }
}
