using Shared.DTOs.Admin.Dashboard;
using System.Net.Http.Json;

namespace GoldenBarbers.Client.Services.Admin
{
    public class AdminDashboardApiService
    {
        private readonly HttpClient _http;

        public AdminDashboardApiService(HttpClient http)
        {
            _http = http; 
        }

        public async Task<AdminDashboardDto?> GetDashboardAsync()
        {
            return await _http.GetFromJsonAsync<AdminDashboardDto>($"api/admin/dashboard") ??
                new AdminDashboardDto();
        }
    }
}
