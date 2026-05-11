using Shared.DTOs.Public;

namespace GoldenBarbers.Services.Public.Interfaces
{
    public interface ICarouselService
    {
        Task<IEnumerable<CarouselDto>> GetCarouselItemsAsync();
    }
}
