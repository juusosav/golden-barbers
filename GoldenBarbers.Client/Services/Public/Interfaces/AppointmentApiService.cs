using Shared.DTOs.Public;

namespace GoldenBarbers.Client.Services.Public.Interfaces
{
    public interface IAppointmentApiService
    {
        Task<List<TimeslotDto>> GetAvailableSlotsAsync(DateTime weekStart);
        Task<AppointmentDto?> CreateAppointmentAsync(AppointmentDto dto);
        Task<AppointmentDto?> GetByIdAsync(Guid id);
    }
}