using GoldenBarbers.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GoldenBarbers.Models.Entities;
using Shared.DTOs;

namespace GoldenBarbers.Services.Public
{
    public class CarouselService
    {
        private readonly ApplicationDbContext _context;

        public CarouselService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<CarouselDto>> GetCarouselItems()
        {
            var allItems = await _context.CarouselItems
                .Select(c => new CarouselDto()
                {
                    Id = c.Id,
                    Image = c.Image,
                    Name = c.Name
                })
                .ToListAsync();

            return allItems;
        }
    }
}
