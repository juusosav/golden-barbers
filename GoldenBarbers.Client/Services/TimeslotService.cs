using System.Net.Http.Json;
using Shared.DTOs;

namespace GoldenBarbers.Client.Services
{
    public class TimeslotService
    {
        private readonly HttpClient _http;

        public TimeslotService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<TimeslotDto>> GetWeeklySlotsAsync(DateTime weekStart)
        {
            Console.WriteLine($"Requesting slots for: {weekStart:yyyy-MM-dd}");
            return await _http.GetFromJsonAsync<List<TimeslotDto>>(
                $"api/appointments/available-slots?weekStart={weekStart:yyyy-MM-dd}") ??
                new List<TimeslotDto>();
        }
    }
}
