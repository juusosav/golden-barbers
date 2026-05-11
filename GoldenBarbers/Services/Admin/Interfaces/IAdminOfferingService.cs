using Shared.DTOs.Admin.Offerings;
using Shared.DTOs.Public;

namespace GoldenBarbers.Services.Admin.Interfaces
{
    public interface IAdminOfferingService
    {
        Task<List<AdminOfferingDto>> GetOfferingsAsync();
        Task<AdminOfferingDto?> GetOfferingByIdAsync(Guid id);
        Task<bool> DeleteOfferingAsync(Guid id);
        Task<bool> EditOfferingAsync(
            Guid id,
            AdminOfferingDto dto,
            IFormFile? file);
        Task<OfferingDto?> CreateOfferingAsync(AdminOfferingDto dto);
    }
}
