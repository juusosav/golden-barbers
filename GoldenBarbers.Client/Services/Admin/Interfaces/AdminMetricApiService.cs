using Shared.DTOs.Admin.Metrics;
using System.Net.Http.Json;

namespace GoldenBarbers.Client.Services.Admin
{
    public interface IAdminMetricApiService
    {
        Task<AdminMetricDto?> GetMetricsAsync();
    }
}
