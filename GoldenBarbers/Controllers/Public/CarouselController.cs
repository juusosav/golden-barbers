using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GoldenBarbers.Data;
using GoldenBarbers.Models.Entities;
using Shared.DTOs.Public;
using GoldenBarbers.Services.Public;

namespace GoldenBarbers.Controllers.Public
{
    [Route("api/carousel")]
    [ApiController]
    public class CarouselController : ControllerBase
    {
        private readonly CarouselService _carouselService;

        public CarouselController(CarouselService carouselService)
        {
            _carouselService = carouselService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarouselDto>>> GetCarouselItemsAsync()
        {
            var allItems = await _carouselService.GetCarouselItemsAsync();

            if (allItems == null)
            {
                return NotFound(); 
            }

            return Ok(allItems);
        }
    }
}
