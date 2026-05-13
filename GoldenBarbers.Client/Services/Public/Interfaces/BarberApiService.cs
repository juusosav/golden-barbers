using Shared.DTOs.Public;

namespace GoldenBarbers.Client.Services.Public.Interfaces
{
    public interface IBarberApiService
    {
        Task<List<BarberDto>> GetBarbersAsync();
        Task<BarberDto?> GetBarberByIdAsync(Guid id);
    }
}