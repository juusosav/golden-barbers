using Shared.DTOs.Admin.Metrics;

namespace GoldenBarbers.Services.Admin.Interfaces
{
    public interface IAdminMetricService
    {
        Task<AdminMetricDto?> GetMetricsAsync();

    }
}
