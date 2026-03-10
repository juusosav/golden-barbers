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

        public async Task<List<AppointmentDto?>> GetAllAppointments()
        {
            return await _http.GetFromJsonAsync<List<AppointmentDto?>>("api/appointments") ??
                new List<AppointmentDto?>();
        }
    }
}
