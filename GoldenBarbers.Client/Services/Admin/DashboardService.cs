using Shared.DTOs.Admin.Dashboard;
using System.Net.Http.Json;

namespace GoldenBarbers.Client.Services.Admin
{
    public class DashboardService
    {
        private readonly HttpClient _http;

        public DashboardService(HttpClient http)
        {
            _http = http; 
        }

        public async Task<DashboardDto?> GetDashboard()
        {
            return await _http.GetFromJsonAsync<DashboardDto>($"api/admin/dashboard");
        }
    }
}
