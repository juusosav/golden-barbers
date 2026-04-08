using GoldenBarbers.Data;
using GoldenBarbers.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.DTOs.Public;

namespace GoldenBarbers.Services.Public
{
    public class OfferingService
    {
        private readonly ApplicationDbContext _context;

        public OfferingService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OfferingDto>> GetAllOfferingsAsync()
        {
            var offerings = await _context.Offerings
                .AsNoTracking()
                .Select(o => new OfferingDto()
                {
                    Id = o.Id,
                    NameFi = o.NameFi,
                    NameEn = o.NameEn,
                    Icon = o.Icon,
                    DescriptionFi = o.DescriptionFi,
                    DescriptionEn = o.DescriptionEn,
                    SeniorPrice = o.SeniorPrice,
                    JuniorPrice = o.JuniorPrice,
                    TraineePrice = o.TraineePrice
                })
                .ToListAsync();

            return offerings;
        }

        public async Task<OfferingDto?> GetOfferingByIdAsync(Guid id)
        {
            var offering = await _context.Offerings
                .AsNoTracking()
                .Where(o => o.Id == id)
                .Select(o => new OfferingDto
                {
                    Id = o.Id,
                    NameFi = o.NameFi,
                    NameEn = o.NameEn,
                    DescriptionFi = o.DescriptionFi,
                    DescriptionEn = o.DescriptionEn,
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
