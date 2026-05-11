using Shared.DTOs.Admin.Appointments;
using Shared.DTOs.Public;

namespace GoldenBarbers.Services.Admin.Interfaces
{
    public interface IAdminAppointmentService
    {
        Task<bool> DeleteAppointmentAsync(Guid id);
        Task<List<AppointmentDto>> GetFilteredAppointmentsAsync(FilterDto filter);
    }
}
