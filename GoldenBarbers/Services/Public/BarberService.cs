using Microsoft.EntityFrameworkCore;
using GoldenBarbers.Data;
using Shared.DTOs.Public;

namespace GoldenBarbers.Services.Public
{
    public class BarberService
    {
        private readonly ApplicationDbContext _context;

        public BarberService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BarberDto>> GetAllBarbersAsync()
        {
            var allBarbers = await _context.Barbers
                .Select(b => new BarberDto
                {
                    Id = b.Id,
                    Name = b.Name,
                    PositionId = b.PositionId,
                    PositionName = b.PositionName,
                    Description = b.Description,
                    Portrait = b.Portrait
                })
                .ToListAsync();

            return allBarbers;
        }

        public async Task<BarberDto?> GetBarberByIdAsync(Guid id)
        {
            var barber = await _context.Barbers
                .Where(b => b.Id == id)
                .Select(b => new BarberDto
                {
                    Id = b.Id,
                    Name = b.Name,
                    PositionId = b.PositionId,
                    PositionName = b.PositionName,
                    Description = b.Description,
                    Portrait = b.Portrait
                })
                .FirstOrDefaultAsync();

            return barber;
        }
    }
}
