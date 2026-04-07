using GoldenBarbers.Data;
using GoldenBarbers.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.DTOs.Admin.Offerings;
using Shared.DTOs.Public;

namespace GoldenBarbers.Services.Admin
{
    public class AdminOfferingService
    {
        private readonly ApplicationDbContext _context;

        public AdminOfferingService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<AdminOfferingDto>> GetOfferingsAsync()
        {
            var offerings = await _context.Offerings
                .Select(o => new AdminOfferingDto()
                {
                    Id = o.Id,
                    Name = o.NameFi,
                    Icon = o.Icon,
                    Description = o.DescriptionFi,
                    SeniorPrice = o.SeniorPrice,
                    JuniorPrice = o.JuniorPrice,
                    TraineePrice = o.TraineePrice
                })
                .ToListAsync();

            return offerings;
        }

        public async Task<AdminOfferingDto?> GetOfferingByIdAsync(Guid id)
        {
            var offering = await _context.Offerings
                .Where(o => o.Id == id)
                .Select(o => new AdminOfferingDto
                {
                    Id = o.Id,
                    Name = o.NameFi,
                    Icon = o.Icon,
                    Description = o.DescriptionFi,
                    SeniorPrice = o.SeniorPrice,
                    JuniorPrice = o.JuniorPrice,
                    TraineePrice = o.TraineePrice
                })
                .FirstOrDefaultAsync();

            return offering;
        }

        public async Task<bool> DeleteOfferingAsync(Guid id)
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

        public async Task<bool> EditOfferingAsync(
            Guid id,
            AdminOfferingDto dto,
            IFormFile? file)
        {
            var offeringToEdit = await _context.Offerings
                .FirstOrDefaultAsync(o => o.Id == id);

            if (offeringToEdit == null)
                return false;

            offeringToEdit.NameFi = dto.Name;
            offeringToEdit.DescriptionFi = dto.Description;
            offeringToEdit.SeniorPrice = dto.SeniorPrice;
            offeringToEdit.JuniorPrice = dto.JuniorPrice;
            offeringToEdit.TraineePrice = dto.TraineePrice;


            if (file != null)
            {
                if (!string.IsNullOrEmpty(offeringToEdit.Icon))
                {
                    var oldPath = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "wwwroot",
                    offeringToEdit.Icon.TrimStart('/')
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

                offeringToEdit.Icon = $"images/{fileName}";
            }

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<OfferingDto?> CreateOfferingAsync(AdminOfferingDto dto)
        {
            var offering = new Offering
            {
                Id = Guid.NewGuid(),
                NameFi = dto.Name,
                Icon = dto.Icon,
                DescriptionFi = dto.Description,
                SeniorPrice = dto.SeniorPrice,
                JuniorPrice = dto.JuniorPrice,
                TraineePrice = dto.TraineePrice
            };

            _context.Offerings.Add(offering);
            await _context.SaveChangesAsync();

            return new OfferingDto
            {
                Id = offering.Id,
                NameFi = offering.NameFi,
                Icon = offering.Icon,
                DescriptionFi = offering.DescriptionFi,
                SeniorPrice = offering.SeniorPrice,
                JuniorPrice = offering.JuniorPrice,
                TraineePrice = offering.TraineePrice
            };
        }
    }
}
