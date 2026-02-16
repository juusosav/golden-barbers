using Shared.DTOs;
using System.Net.Http.Json;

namespace GoldenBarbers.Client.Services
{
    public class CarouselService
    {
        private readonly HttpClient _http;

        public CarouselService(HttpClient http)
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
