using Shared.DTOs.Public;

namespace GoldenBarbers.Services.Public.Interfaces
{
    public interface IAppointmentService
    {
        Task<List<TimeslotDto>> GetAvailableSlotsAsync(DateTime weekStart);
        Task<int> CalculateAppointmentPriceAsync(Guid offeringId, int barberPositionId);
        Task<AppointmentDto?> GetByIdAsync(Guid id);
        Task<AppointmentDto?> CreateAppointmentAsync(AppointmentDto dto);
    }
}
