using GoldenBarbers.Data;
using GoldenBarbers.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.DTOs;

namespace GoldenBarbers.Services.Admin
{
    public class AdminOfferingsService
    {
        private readonly ApplicationDbContext _context;

        public AdminOfferingsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OfferingDto>> GetAllOfferings()
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

            return offerings;
        }

        public async Task<OfferingDto?> GetOfferingById(Guid id)
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

            return offering;
        }
    }
}
