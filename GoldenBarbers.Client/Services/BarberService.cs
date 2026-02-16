using Shared.DTOs;
using System.Net.Http.Json;

namespace GoldenBarbers.Client.Services
{
    public class BarberService
    {
        private readonly HttpClient _http;

        public BarberService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<BarberDto>> GetBarbersAsync()
        {
                return await _http.GetFromJsonAsync<List<BarberDto>>("api/barbers")
                    ?? new List<BarberDto>();
        }

        public async Task<BarberDto?> GetBarberById(Guid id)
        {
            return await _http.GetFromJsonAsync<BarberDto>($"api/barbers/{id}");
        }
    }
}
