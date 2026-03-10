using GoldenBarbers.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;
using GoldenBarbers.Models.Entities;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using GoldenBarbers.Services.Public;

namespace GoldenBarbers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferingsController : ControllerBase
    {
        private readonly OfferingsService _offeringsService;

        public OfferingsController(OfferingsService offeringsService)
        {
            _offeringsService = offeringsService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OfferingDto>>> GetAllOfferings()
        {
            var offerings = await _offeringsService.GetAllOfferings();

            if (offerings == null)
            {
                return NotFound(); 
            }

            return Ok(offerings);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OfferingDto>> GetOfferingById(Guid id)
        {
            var offering = await _offeringsService.GetOfferingById(id);

            if (offering == null)
            {
                return NotFound(); 
            }

            return Ok(offering);
        }
    }
}
