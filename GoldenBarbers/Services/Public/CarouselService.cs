using GoldenBarbers.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GoldenBarbers.Models.Entities;
using Shared.DTOs.Public;

namespace GoldenBarbers.Services.Public
{
    public class CarouselService
    {
        private readonly ApplicationDbContext _context;

        public CarouselService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<CarouselDto>> GetCarouselItemsAsync()
        {
            var allItems = await _context.CarouselItems
                .Select(c => new CarouselDto()
                {
                    Id = c.Id,
                    Image = c.Image,
                    NameFi = c.NameFi,
                    NameEn = c.NameEn
                })
                .ToListAsync();

            return allItems;
        }
    }
}
