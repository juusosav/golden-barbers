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
    public class CarouselController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CarouselController(ApplicationDbContext context)
        {
            _context = context; 
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarouselDto>>> GetCarouselItems()
        {
            var allItems = await _context.CarouselItems
                .Select(c => new CarouselDto()
                {
                    Id = c.Id,
                    Image = c.Image,
                    Name = c.Name
                })
                .ToListAsync();

            return Ok(allItems);
        }
    }
}
