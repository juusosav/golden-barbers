using Shared.DTOs;
using System.Net.Http.Json;

namespace GoldenBarbers.Client.Services
{
    public class OfferingService
    {
        private readonly HttpClient _http;

        public OfferingService(HttpClient http)
        {
            _http = http; 
        }

        public async Task<List<OfferingDto>> GetAllOfferingsAsync()
        {
            return await _http.GetFromJsonAsync<List<OfferingDto>>("api/offerings")
                ?? new List<OfferingDto>();
        }

        public async Task<OfferingDto?> GetOfferingById(Guid id)
        {
            return await _http.GetFromJsonAsync<OfferingDto>($"api/offerings/{id}");
        }
    }
}
