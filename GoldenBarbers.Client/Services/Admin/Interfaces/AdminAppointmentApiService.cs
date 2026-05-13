using Shared.DTOs.Public;
using Shared.DTOs.Admin.Appointments;

namespace GoldenBarbers.Client.Services.Admin.Interfaces
{
    public interface IAdminAppointmentApiService
    {

        Task<List<AppointmentDto>> GetAppointmentsAsync(FilterDto filter);

        Task<bool> DeleteAppointmentAsync(Guid id);
    }
}
