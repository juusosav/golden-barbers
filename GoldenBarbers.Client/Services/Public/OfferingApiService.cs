using Shared.DTOs.Public;
using System.Net.Http.Json;

namespace GoldenBarbers.Client.Services.Public
{
    public class OfferingApiService
    {
        private readonly HttpClient _http;

        public OfferingApiService(HttpClient http)
        {
            _http = http; 
        }

        public async Task<List<OfferingDto>> GetAllOfferingsAsync()
        {
            return await _http.GetFromJsonAsync<List<OfferingDto>>("api/offerings")
                ?? new List<OfferingDto>();
        }

        public async Task<OfferingDto?> GetOfferingByIdAsync(Guid id)
        {
            return await _http.GetFromJsonAsync<OfferingDto>($"api/offerings/{id}");
        }
    }
}
