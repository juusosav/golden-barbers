using Shared.DTOs;
using System.Net.Http.Json;

namespace GoldenBarbers.Client.Services
{
    public class AppointmentsService
    {
        private readonly HttpClient _http;

        public AppointmentsService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<TimeslotDto>> GetAvailableSlotsAsync(DateTime weekStart)
        {
            var query = $"api/appointments/available-slots?weekStart={weekStart:yyyy-MM-dd}";

            return await _http.GetFromJsonAsync<List<TimeslotDto>>(query)
                ?? new List<TimeslotDto>();
        }

        public async Task CreateAppointmentAsync(AppointmentDto dto)
        {
            await _http.PostAsJsonAsync("api/appointments", dto);
        }

        public async Task<AppointmentDto?> GetByIdAsync(Guid id)
        {
            return await _http.GetFromJsonAsync<AppointmentDto>($"api/appointments/{id}");
        }
    }
}
