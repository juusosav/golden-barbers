using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GoldenBarbers.Data;
using GoldenBarbers.Models.Entities;
using Shared.DTOs;

namespace GoldenBarbers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarbersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BarbersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BarberDto>>> GetAllBarbers()
        {
            var allBarbers = await _context.Barbers
                .Select(b => new BarberDto
                {
                    Id = b.Id,
                    Name = b.Name,
                    Position = b.Position,
                    Description = b.Description,
                    Portrait = b.Portrait
                })
                .ToListAsync();

            return Ok(allBarbers);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Barber>> GetBarberById(Guid id)
        {
            var barber = await _context.Barbers
                .Where(b => b.Id == id)
                .Select(b => new BarberDto
                {
                    Id = b.Id,
                    Name = b.Name,
                    Position = b.Position,
                    Description = b.Description,
                    Portrait = b.Portrait
                })
                .FirstOrDefaultAsync();

            if (barber == null)
            {
                return NotFound();
            }
            return Ok(barber);
        }
    }
}
