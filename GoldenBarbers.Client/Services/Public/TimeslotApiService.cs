using System.Net.Http.Json;
using Shared.DTOs.Public;

namespace GoldenBarbers.Client.Services.Public
{
    public class TimeslotApiService
    {
        private readonly HttpClient _http;

        public TimeslotApiService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<TimeslotDto>> GetWeeklySlotsAsync(DateTime weekStart)
        {
            return await _http.GetFromJsonAsync<List<TimeslotDto>>(
                $"api/appointments/available-slots?weekStart={weekStart:yyyy-MM-dd}") ??
                new List<TimeslotDto>();
        }
    }
}
