using Shared.DTOs.Admin.Offerings;
using System.Net.Http.Json;

namespace GoldenBarbers.Client.Services.Admin
{
    public class AdminOfferingsApiService
    {
        private readonly HttpClient _http;

        public AdminOfferingsApiService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<AdminOfferingDto>> GetOfferings()
        {
            return await _http.GetFromJsonAsync<List<AdminOfferingDto>>($"api/admin/offerings")
                ?? new List<AdminOfferingDto>();
        }

        public async Task<AdminOfferingDto?> GetOfferingById(Guid id)
        {
            return await _http.GetFromJsonAsync<AdminOfferingDto>($"api/admin/offerings/{id}");
        }

        public async Task<bool> DeleteOffering(Guid id)
        {
            var response = await _http.DeleteAsync($"api/admin/offerings/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> EditOffering(Guid id, AdminOfferingDto dto)
        {
            var response = await _http.PutAsJsonAsync($"api/admin/offerings/{id}", dto);
            return response.IsSuccessStatusCode;
        }
    }
}
