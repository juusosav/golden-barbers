using Shared.DTOs.Admin.Dashboard;

namespace GoldenBarbers.Client.Services.Admin.Interfaces
{
    public interface IAdminDashboardApiService
    {
        Task<AdminDashboardDto?> GetDashboardAsync();
    }
}
