using Shared.DTOs.Admin.Barbers;
using System.Net.Http.Json;

namespace GoldenBarbers.Client.Services.Admin
{
    public class AdminBarbersApiService
    {
        private readonly HttpClient _http;

        public AdminBarbersApiService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<AdminBarberDto>> GetAllBarbers()
        {
            return await _http.GetFromJsonAsync<List<AdminBarberDto>>("api/admin/barbers") 
                ?? new List<AdminBarberDto>();
        }

        public async Task<AdminBarberDto?> GetBarberById(Guid id)
        {
            return await _http.GetFromJsonAsync<AdminBarberDto>($"api/admin/barbers/{id}");
        }

        public async Task<bool> DeleteBarberAsync(Guid id)
        {
            var response = await _http.DeleteAsync($"api/admin/barbers/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> EditBarberAsync(Guid id, AdminBarberDto dto)
        {
            var response = await _http.PutAsJsonAsync($"api/admin/barbers/{id}", dto);
            return response.IsSuccessStatusCode;
        }
    }
}
