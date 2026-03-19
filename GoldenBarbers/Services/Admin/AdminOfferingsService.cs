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

        public async Task<AdminOfferingDto?> GetOfferingById(Guid id)
        {
            var offering = await _context.Offerings
                .Where(o => o.Id == id)
                .Select(o => new AdminOfferingDto
                {
                    Id = o.Id,
                    Name = o.Name,
                    Icon = o.Icon,
                    Description = o.Description,
                    SeniorPrice = o.SeniorPrice,
                    JuniorPrice = o.JuniorPrice,
                    TraineePrice = o.TraineePrice
                })
                .FirstOrDefaultAsync();

            return offering;
        }

        public async Task<bool> DeleteOffering(Guid id)
        {
            var offeringToDelete = await _context.Offerings.FindAsync(id);

            if (offeringToDelete == null)
                return false;

            if (!string.IsNullOrEmpty(offeringToDelete.Icon))
            {
                var filePath = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "wwwroot",
                    offeringToDelete.Icon.TrimStart('/')
                    );

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }

            _context.Offerings.Remove(offeringToDelete);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> EditOffering(Guid id, AdminOfferingDto dto)
        {
            var offeringToEdit = await _context.Offerings.FirstOrDefaultAsync(o => o.Id == id);

            if (offeringToEdit == null)
                return false;

            if (!string.IsNullOrEmpty(offeringToEdit.Icon))
            {
                var filePath = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "wwwroot",
                    offeringToEdit.Icon.TrimStart('/')
                    );

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }

            offeringToEdit.Name = dto.Name;
            offeringToEdit.Icon = dto.Icon;
            offeringToEdit.Description = dto.Description;
            offeringToEdit.SeniorPrice = dto.SeniorPrice;
            offeringToEdit.JuniorPrice = dto.JuniorPrice;
            offeringToEdit.TraineePrice = dto.TraineePrice;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Offering> CreateOffering(AdminOfferingDto dto)
        {
            var offering = new Offering
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Icon = dto.Icon,
                Description = dto.Description,
                SeniorPrice = dto.SeniorPrice,
                JuniorPrice = dto.JuniorPrice,
                TraineePrice = dto.TraineePrice
            };

            _context.Offerings.Add(offering);
            await _context.SaveChangesAsync();

            return offering;
        }
    }
}
