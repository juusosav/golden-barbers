using GoldenBarbers.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.DTOs.Admin.Barbers;

namespace GoldenBarbers.Services.Admin
{
    public class AdminBarbersService
    {
        private readonly ApplicationDbContext _context;

        public AdminBarbersService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AdminBarberDto>> GetAllBarbers()
        {
            var barbers = await _context.Barbers
                .Select(b => new AdminBarberDto
                {
                    Id = b.Id,
                    Name = b.Name,
                    PositionId = b.PositionId,
                    PositionName = b.PositionName,
                    Portrait = b.Portrait,
                    PersonalPhone = b.PersonalPhone,
                    PersonalEmail = b.PersonalEmail,
                    PersonalAddress = b.PersonalAddress,
                    Salary = b.Salary,
                    StartDate = b.StartDate
                })
                .ToListAsync();

            return barbers;
        }
    }
}
