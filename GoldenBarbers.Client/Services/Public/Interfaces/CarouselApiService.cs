using Shared.DTOs.Public;
using System.Net.Http.Json;

namespace GoldenBarbers.Client.Services.Public
{
    public interface ICarouselApiService
    {
        Task<List<CarouselDto>> GetCarouselItemsAsync();
    }
}