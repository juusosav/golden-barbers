using Shared.DTOs.Admin.Metrics;
using System.Net.Http.Json;

namespace GoldenBarbers.Client.Services.Admin.Interfaces
{
    public interface IAdminMetricApiService
    {
        Task<AdminMetricDto?> GetMetricsAsync();
    }
}
