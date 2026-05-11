using Shared.DTOs.Admin.Barbers;

namespace GoldenBarbers.Services.Admin.Interfaces
{
    public interface IAdminBarberService
    {
        Task<IEnumerable<AdminBarberDto>> GetAllBarbersAsync();
        Task<AdminBarberDto?> GetBarberByIdAsync(Guid id);
        Task<bool> DeleteBarberAsync(Guid id);
        Task<bool> EditBarberAsync(
            Guid id,
            AdminBarberDto dto);
        Task<AdminBarberDto> CreateBarberAsync(AdminBarberDto dto);
    }
}
