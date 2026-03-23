using GoldenBarbers.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            AdminBarberDto dto,
            IFormFile? file)
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

            if (file != null)
            {
                if (!string.IsNullOrEmpty(barberToEdit.Portrait))
                {
                    var oldPath = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "wwwroot",
                    barberToEdit.Portrait.TrimStart('/')
                    );

                    if (File.Exists(oldPath))
                    {
                        File.Delete(oldPath);
                    }
                }

                var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                var newPath = Path.Combine("wwwroot/images", fileName);

                using (var stream = new FileStream(newPath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                barberToEdit.Portrait = $"images/{fileName}";
            }

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
