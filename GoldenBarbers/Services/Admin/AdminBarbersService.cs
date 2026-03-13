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

        public async Task<AdminBarberDto?> GetBarberById(Guid id)
        {
            var barber = await _context.Barbers
                .Where(b => b.Id == id)
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
                .FirstOrDefaultAsync();

            return barber;
        }

        public async Task<bool> DeleteBarberAsync(Guid id)
        {
            var barberToDelete = await _context.Barbers.FindAsync(id);

            if (barberToDelete == null)
                return false;

            _context.Barbers.Remove(barberToDelete);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> EditBarberAsync(Guid id, AdminBarberDto dto)
        {
            var barberToEdit = await _context.Barbers.FirstOrDefaultAsync(b => b.Id == id);

            if (barberToEdit == null)
                return false;

            barberToEdit.Name = dto.Name;
            barberToEdit.PositionId = dto.PositionId;
            barberToEdit.PositionName = dto.PositionName;
            barberToEdit.Portrait = dto.Portrait;
            barberToEdit.PersonalPhone = dto.PersonalPhone;
            barberToEdit.PersonalEmail= dto.PersonalEmail;
            barberToEdit.PersonalAddress = dto.PersonalAddress;
            barberToEdit.Salary = dto.Salary;
            barberToEdit.StartDate = dto.StartDate;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
