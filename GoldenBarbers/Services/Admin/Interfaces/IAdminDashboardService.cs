using Shared.DTOs.Admin.Dashboard;

namespace GoldenBarbers.Services.Admin.Interfaces
{
    public interface IAdminDashboardService
    {
        Task<AdminDashboardDto> GetDashboardAsync();

    }
}
