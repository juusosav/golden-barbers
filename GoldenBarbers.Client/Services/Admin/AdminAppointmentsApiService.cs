using Shared.DTOs;
using Shared.DTOs.Admin.Appointments;
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

        public async Task<List<AppointmentDto>> GetAppointments(FilterDto filter)
        {
            var url =
                $"api/admin/appointments?" +
                $"Page={filter.Page}&PageSize={filter.PageSize}";

            if (!string.IsNullOrWhiteSpace(filter.BarberName))
            {
                url += $"&BarberName={filter.BarberName}";
            }

            if (!string.IsNullOrWhiteSpace(filter.OfferingName))
            {
                url += $"&OfferingName={filter.OfferingName}";
            }

            if (filter.DateFrom != null)
            {
                url += $"&DateFrom={filter.DateFrom}";
            }

            if (!string.IsNullOrWhiteSpace(filter.CustomerName))
            {
                url += $"&CustomerName={filter.CustomerName}";
            }

            if (!string.IsNullOrWhiteSpace(filter.SearchTerm))
            {
                url += $"&SearchTerm={filter.SearchTerm}";
                url += $"&SearchBy={filter.SearchBy}";
            }

            return await _http.GetFromJsonAsync<List<AppointmentDto>>(url) 
                ?? new List<AppointmentDto>();
        }

        public async Task<bool> DeleteAppointmentAsync(Guid id)
        {
            var response = await _http.DeleteAsync($"api/admin/appointments/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
