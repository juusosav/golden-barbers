using GoldenBarbers.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs.Public;
using GoldenBarbers.Models.Entities;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using GoldenBarbers.Services.Public;

namespace GoldenBarbers.Controllers.Public
{
    [Route("api/offerings")]
    [ApiController]
    public class OfferingController : ControllerBase
    {
        private readonly OfferingService _offeringService;

        public OfferingController(OfferingService offeringService)
        {
            _offeringService = offeringService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OfferingDto>>> GetAllOfferingsAsync()
        {
            var offerings = await _offeringService.GetAllOfferingsAsync();

            if (offerings == null)
            {
                return NotFound(); 
            }

            return Ok(offerings);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OfferingDto>> GetOfferingByIdAsync(Guid id)
        {
            var offering = await _offeringService.GetOfferingByIdAsync(id);

            if (offering == null)
            {
                return NotFound(); 
            }

            return Ok(offering);
        }
    }
}
