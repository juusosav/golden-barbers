using Shared.DTOs.Public;
using System.Net.Http.Json;
using GoldenBarbers.Client.Services.Public.Interfaces;

namespace GoldenBarbers.Client.Services.Public
{
    public class CarouselApiService : ICarouselApiService
    {
        private readonly HttpClient _http;

        public CarouselApiService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<CarouselDto>> GetCarouselItemsAsync()
        {
            return await _http.GetFromJsonAsync<List<CarouselDto>>("api/carousel")
                ?? new List<CarouselDto>();
        }
    }
}
