using Microsoft.AspNetCore.Components.Forms;
using Shared.DTOs.Admin.Offerings;
using System.Net.Http.Json;

namespace GoldenBarbers.Client.Services.Admin.Interfaces
{
    public interface IAdminOfferingApiService
    {
        Task<List<AdminOfferingDto>> GetOfferingsAsync();
        Task<AdminOfferingDto?> GetOfferingByIdAsync(Guid id);
        Task<bool> DeleteOfferingAsync(Guid id);
        Task<bool> EditOfferingAsync(Guid id, AdminOfferingDto dto, IBrowserFile? file);
        Task<AdminOfferingDto?> CreateOfferingAsync(AdminOfferingDto dto, IBrowserFile? file);
    }
}