using Microsoft.AspNetCore.Components.Forms;
using Shared.DTOs.Admin.Barbers;
using System.Globalization;
using System.Net.Http.Json;

namespace GoldenBarbers.Client.Services.Admin.Interfaces
{
    public interface IAdminBarberApiService
    {
        Task<List<AdminBarberDto>> GetAllBarbersAsync();
        Task<AdminBarberDto?> GetBarberByIdAsync(Guid id);
        Task<bool> DeleteBarberAsync(Guid id);
        Task<bool> EditBarberAsync(Guid id, AdminBarberDto dto, IBrowserFile? file);
        Task<AdminBarberDto?> CreateBarberAsync(AdminBarberDto dto, IBrowserFile? file);
    }
}