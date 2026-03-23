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

        public async Task<DashboardDto?> GetDashboardAsync()
        {
            return await _http.GetFromJsonAsync<DashboardDto>($"api/admin/dashboard") ??
                new DashboardDto();
        }
    }
}
