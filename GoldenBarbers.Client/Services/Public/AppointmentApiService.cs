using Shared.DTOs.Public;
using System.Net.Http.Json;

namespace GoldenBarbers.Client.Services.Public
{
    public class AppointmentApiService
    {
        private readonly HttpClient _http;

        public AppointmentApiService(HttpClient http)
        {
            _http = http;
        }

        private const string BaseRoute = "api/appointments";

        public async Task<List<TimeslotDto>> GetAvailableSlotsAsync(DateTime weekStart)
        {
            var query = $"{BaseRoute}/available-slots?weekStart={weekStart:yyyy-MM-dd}";

            return await _http.GetFromJsonAsync<List<TimeslotDto>>(query)
                ?? new List<TimeslotDto>();
        }

        public async Task<AppointmentDto?> CreateAppointmentAsync(AppointmentDto dto)
        {
            var response = await _http.PostAsJsonAsync(BaseRoute, dto);

            if (!response.IsSuccessStatusCode)
                return null;

            return await response.Content.ReadFromJsonAsync<AppointmentDto>();
        }

        public async Task<AppointmentDto?> GetByIdAsync(Guid id)
        {
            try
            {
                return await _http.GetFromJsonAsync<AppointmentDto>($"{BaseRoute}/{id}");
            }
            catch (HttpRequestException)
            {
                return null;
            }
        }
    }
}
