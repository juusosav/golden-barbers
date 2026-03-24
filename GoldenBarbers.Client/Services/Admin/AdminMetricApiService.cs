using Shared.DTOs.Admin.Metrics;
using System.Net.Http.Json;

namespace GoldenBarbers.Client.Services.Admin
{
    public class AdminMetricApiService
    {
        private readonly HttpClient _http;

        public AdminMetricApiService(HttpClient http)
        {
            _http = http;
        }

        public async Task<AdminMetricDto?> GetMetricsAsync()
        {
            return await _http.GetFromJsonAsync<AdminMetricDto?>($"api/admin/metrics")
                ?? new AdminMetricDto();
        }
    }
}
