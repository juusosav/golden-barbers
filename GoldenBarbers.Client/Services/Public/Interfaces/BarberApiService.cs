using Shared.DTOs.Public;
using System.Net.Http.Json;

namespace GoldenBarbers.Client.Services.Public
{
    public interface IBarberApiService
    {
        Task<List<BarberDto>> GetBarbersAsync();
        Task<BarberDto?> GetBarberByIdAsync(Guid id);
    }
}