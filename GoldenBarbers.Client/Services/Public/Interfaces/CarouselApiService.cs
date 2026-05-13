using Shared.DTOs.Public;

namespace GoldenBarbers.Client.Services.Public.Interfaces
{
    public interface ICarouselApiService
    {
        Task<List<CarouselDto>> GetCarouselItemsAsync();
    }
}