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
    public class CarouselController : ControllerBase
    {
        private readonly CarouselService _carouselService;

        public CarouselController(CarouselService carouselService)
        {
            _carouselService = carouselService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarouselDto>>> GetCarouselItems()
        {
            var allItems = await _carouselService.GetCarouselItems();

            if (allItems == null)
            {
                return NotFound(); 
            }

            return Ok(allItems);
        }
    }
}
