using Shared.DTOs.Admin.Dashboard;
using System.Net.Http.Json;

namespace GoldenBarbers.Client.Services.Admin
{
    public interface IAdminDashboardApiService
    {
        Task<AdminDashboardDto?> GetDashboardAsync();
    }
}
