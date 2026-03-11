using Shared.DTOs;
using System.Net.Http.Json;

namespace GoldenBarbers.Client.Services.Admin
{
    public class AdminAppointmentsApiService
    {
        private readonly HttpClient _http;

        public AdminAppointmentsApiService(HttpClient http)
        {
            _http = http; 
        }

        public async Task<List<AppointmentDto>?> GetAllAppointments()
        {
            return await _http.GetFromJsonAsync<List<AppointmentDto>?>("api/admin/appointments") ??
                new List<AppointmentDto>();
        }

        public async Task<bool> DeleteAppointmentAsync(Guid id)
        {
            var response = await _http.DeleteAsync($"api/admin/appointments/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
