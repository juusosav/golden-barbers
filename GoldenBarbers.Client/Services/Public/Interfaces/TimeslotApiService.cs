using Shared.DTOs.Public;

namespace GoldenBarbers.Client.Services.Public.Interfaces
{
    public interface ITimeslotApiService
    {
        Task<List<TimeslotDto>> GetWeeklySlotsAsync(DateTime weekStart);
    }
}