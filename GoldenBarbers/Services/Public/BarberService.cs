using Microsoft.EntityFrameworkCore;
using GoldenBarbers.Data;
using Shared.DTOs.Public;
using GoldenBarbers.Services.Public.Interfaces;

namespace GoldenBarbers.Services.Public
{
    public class BarberService : IBarberService
    {
        private readonly ApplicationDbContext _context;

        public BarberService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BarberDto>> GetAllBarbersAsync()
        {
            var allBarbers = await _context.Barbers
                .AsNoTracking()
                .Select(b => new BarberDto
                {
                    Id = b.Id,
                    Name = b.Name,
                    PositionId = b.PositionId,
                    PositionName = b.PositionName,
                    DescriptionFi = b.DescriptionFi,
                    DescriptionEn = b.DescriptionEn,
                    Portrait = b.Portrait
                })
                .ToListAsync();

            return allBarbers;
        }

        public async Task<BarberDto?> GetBarberByIdAsync(Guid id)
        {
            var barber = await _context.Barbers
                .AsNoTracking()
                .Where(b => b.Id == id)
                .Select(b => new BarberDto
                {
                    Id = b.Id,
                    Name = b.Name,
                    PositionId = b.PositionId,
                    PositionName = b.PositionName,
                    DescriptionFi = b.DescriptionFi,
                    DescriptionEn= b.DescriptionEn,
                    Portrait = b.Portrait
                })
                .FirstOrDefaultAsync();

            return barber;
        }
    }
}
