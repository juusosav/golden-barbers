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
            var weekStartString = weekStart.ToString("yyyy-MM-dd");

            return await _http.GetFromJsonAsync<List<TimeslotDto>>(
                $"api/appointments/weekly?weekStart={weekStartString}") ??
                new List<TimeslotDto>();
        }
    }
}
