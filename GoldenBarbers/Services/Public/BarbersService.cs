using Microsoft.EntityFrameworkCore;
using GoldenBarbers.Data;
using Shared.DTOs;

namespace GoldenBarbers.Services.Public
{
    public class BarbersService
    {
        private readonly ApplicationDbContext _context;

        public BarbersService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BarberDto>> GetAllBarbers()
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

        public async Task<BarberDto?> GetBarberById(Guid id)
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
