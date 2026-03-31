using GoldenBarbers.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GoldenBarbers.Models.Entities;
using Shared.DTOs.Admin.Barbers;

namespace GoldenBarbers.Services.Admin
{
    public class AdminBarberService
    {
        private readonly ApplicationDbContext _context;

        public AdminBarberService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AdminBarberDto>> GetAllBarbersAsync()
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

        public async Task<AdminBarberDto?> GetBarberByIdAsync(Guid id)
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

        public async Task<bool> EditBarberAsync(
            Guid id,
            AdminBarberDto dto)
        {
            var barberToEdit = await _context.Barbers
                .FirstOrDefaultAsync(b => b.Id == id);

            if (barberToEdit == null)
                return false;

            barberToEdit.Name = dto.Name;
            barberToEdit.PositionId = dto.PositionId;
            barberToEdit.PositionName = dto.PositionName;
            barberToEdit.PersonalPhone = dto.PersonalPhone;
            barberToEdit.PersonalEmail = dto.PersonalEmail;
            barberToEdit.PersonalAddress = dto.PersonalAddress;
            barberToEdit.Salary = dto.Salary;
            barberToEdit.StartDate = dto.StartDate;
            barberToEdit.Portrait = dto.Portrait;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<AdminBarberDto> CreateBarberAsync(AdminBarberDto dto)
        {
            var barber = new Barber
            {
                Name = dto.Name,
                PositionId = dto.PositionId,
                PositionName = dto.PositionName,
                PersonalPhone = dto.PersonalPhone,
                PersonalEmail = dto.PersonalEmail,
                PersonalAddress = dto.PersonalAddress,
                Salary = dto.Salary,
                StartDate = dto.StartDate,
                Portrait = dto.Portrait
            };

            _context.Barbers.Add(barber);
            await _context.SaveChangesAsync();

            return new AdminBarberDto
            {
                Name = barber.Name,
                PositionId = barber.PositionId,
                PositionName = barber.PositionName,
                PersonalPhone = barber.PersonalPhone,
                PersonalEmail = barber.PersonalEmail,
                PersonalAddress = barber.PersonalAddress,
                Salary = barber.Salary,
                StartDate = barber.StartDate,
                Portrait = barber.Portrait
            };
        }
    }
}
