using Shared.DTOs.Public;
using System.Net.Http.Json;

namespace GoldenBarbers.Client.Services.Public
{
    public interface IAppointmentApiService
    {
        Task<List<TimeslotDto>> GetAvailableSlotsAsync(DateTime weekStart);
        Task<AppointmentDto?> CreateAppointmentAsync(AppointmentDto dto);
        Task<AppointmentDto?> GetByIdAsync(Guid id);
    }
}