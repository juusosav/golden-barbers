using GoldenBarbers.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;
using GoldenBarbers.Models.Entities;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferingsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OfferingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OfferingDto>>> GetAllOfferings()
        {
            var offerings = await _context.Offerings
                .Select(o => new OfferingDto()
                {
                    Id = o.Id,
                    Name = o.Name,
                    Icon = o.Icon,
                    Description = o.Description,
                    SeniorPrice = o.SeniorPrice,
                    JuniorPrice = o.JuniorPrice,
                    TraineePrice = o.TraineePrice
                })
                .ToListAsync();

            return Ok(offerings);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Offering>> GetOfferingById(Guid id)
        {
            var offering = await _context.Offerings
                .Where(o => o.Id == id)
                .Select(o => new OfferingDto
                {
                    Id = o.Id,
                    Name = o.Name,
                    Description = o.Description,
                    Icon = o.Icon,
                    TraineePrice = o.TraineePrice,
                    JuniorPrice = o.JuniorPrice,
                    SeniorPrice = o.SeniorPrice
                })
                .FirstOrDefaultAsync();

            return Ok(offering);
        }
    }
}
