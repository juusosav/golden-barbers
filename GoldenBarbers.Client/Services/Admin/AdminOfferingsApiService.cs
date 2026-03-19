using Microsoft.AspNetCore.Components.Forms;
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

        public async Task<bool> EditOffering(Guid id, AdminOfferingDto dto, IBrowserFile? file)
        {
            var content = new MultipartFormDataContent();

            content.Add(new StringContent(dto.Name), "Name");
            content.Add(new StringContent(dto.Description), "Description");
            content.Add(new StringContent(dto.SeniorPrice.ToString()), "SeniorPrice");
            content.Add(new StringContent(dto.JuniorPrice.ToString()), "JuniorPrice");
            content.Add(new StringContent(dto.TraineePrice.ToString()), "TraineePrice");

            if (file != null)
            {
                var stream = file.OpenReadStream(5 * 1024 * 1024);
                var fileContent = new StreamContent(stream);
                fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(file.ContentType);

                content.Add(fileContent, "file", file.Name);
            }

            var response = await _http.PutAsync($"api/admin/offerings/{id}", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<AdminOfferingDto?> CreateOffering(AdminOfferingDto dto, IBrowserFile? file)
        {
            var content = new MultipartFormDataContent();

            content.Add(new StringContent(dto.Name), "Name");
            content.Add(new StringContent(dto.Description), "Description");
            content.Add(new StringContent(dto.SeniorPrice.ToString()), "SeniorPrice");
            content.Add(new StringContent(dto.JuniorPrice.ToString()), "JuniorPrice");
            content.Add(new StringContent(dto.TraineePrice.ToString()), "TraineePrice");

            if (file != null)
            {
                var stream = file.OpenReadStream(5 * 1024 * 1024);
                var fileContent = new StreamContent(stream);
                fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(file.ContentType);

                content.Add(fileContent, "file", file.Name);
            }

            var response = await _http.PostAsync($"api/admin/offerings", content);

            if (!response.IsSuccessStatusCode)
                return null;

            return await response.Content.ReadFromJsonAsync<AdminOfferingDto>();
        }
    }
}
