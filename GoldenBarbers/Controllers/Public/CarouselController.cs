using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GoldenBarbers.Data;
using GoldenBarbers.Models.Entities;
using Shared.DTOs.Public;
using GoldenBarbers.Services.Public;
using GoldenBarbers.Services.Public.Interfaces;

namespace GoldenBarbers.Controllers.Public
{
    [Route("api/carousel")]
    [ApiController]
    public class CarouselController : ControllerBase
    {
        private readonly ICarouselService _carouselService;

        public CarouselController(ICarouselService carouselService)
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
