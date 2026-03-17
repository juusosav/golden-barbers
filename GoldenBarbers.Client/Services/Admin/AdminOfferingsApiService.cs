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
    }
}
