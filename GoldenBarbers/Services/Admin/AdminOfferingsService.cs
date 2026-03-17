using GoldenBarbers.Data;
using GoldenBarbers.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.DTOs.Admin.Offerings;

namespace GoldenBarbers.Services.Admin
{
    public class AdminOfferingsService
    {
        private readonly ApplicationDbContext _context;

        public AdminOfferingsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<AdminOfferingDto>> GetOfferings()
        {
            var offerings = await _context.Offerings
                .Select(o => new AdminOfferingDto()
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

    }
}
