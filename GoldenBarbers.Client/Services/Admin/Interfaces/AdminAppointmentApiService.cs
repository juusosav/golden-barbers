using Shared.DTOs.Public;
using Shared.DTOs.Admin.Appointments;
using System.Net.Http.Json;

namespace GoldenBarbers.Client.Services.Admin
{
    public interface IAdminAppointmentApiService
    {

        Task<List<AppointmentDto>> GetAppointmentsAsync(FilterDto filter);

        Task<bool> DeleteAppointmentAsync(Guid id);
    }
}
