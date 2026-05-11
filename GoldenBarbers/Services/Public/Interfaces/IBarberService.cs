using Shared.DTOs.Public;

namespace GoldenBarbers.Services.Public.Interfaces
{
    public interface IBarberService
    {
        Task<IEnumerable<BarberDto>> GetAllBarbersAsync();
        Task<BarberDto?> GetBarberByIdAsync(Guid id);

    }
}
