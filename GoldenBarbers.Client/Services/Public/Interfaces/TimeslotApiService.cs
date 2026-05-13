using System.Net.Http.Json;
using Shared.DTOs.Public;

namespace GoldenBarbers.Client.Services.Public
{
    public interface ITimeslotApiService
    {
        Task<List<TimeslotDto>> GetWeeklySlotsAsync(DateTime weekStart);
    }
}