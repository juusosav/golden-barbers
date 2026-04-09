using Microsoft.AspNetCore.Components.Forms;
using Shared.DTOs.Admin.Offerings;
using System.Net.Http.Json;

namespace GoldenBarbers.Client.Services.Admin
{
    public class AdminOfferingApiService
    {
        private readonly HttpClient _http;

        public AdminOfferingApiService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<AdminOfferingDto>> GetOfferingsAsync()
        {
            return await _http.GetFromJsonAsync<List<AdminOfferingDto>>($"api/admin/offerings")
                ?? new List<AdminOfferingDto>();
        }

        public async Task<AdminOfferingDto?> GetOfferingByIdAsync(Guid id)
        {
            return await _http.GetFromJsonAsync<AdminOfferingDto>($"api/admin/offerings/{id}");
        }

        public async Task<bool> DeleteOfferingAsync(Guid id)
        {
            var response = await _http.DeleteAsync($"api/admin/offerings/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> EditOfferingAsync(
            Guid id, 
            AdminOfferingDto dto, 
            IBrowserFile? file)
        {
            var content = new MultipartFormDataContent();

            content.Add(new StringContent(dto.NameFi), "NameFi");
            content.Add(new StringContent(dto.NameEn), "NameEn");
            content.Add(new StringContent(dto.DescriptionFi), "DescriptionFi");
            content.Add(new StringContent(dto.DescriptionEn), "DescriptionEn");
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

        public async Task<AdminOfferingDto?> CreateOfferingAsync(
            AdminOfferingDto dto, 
            IBrowserFile? file)
        {
            var content = new MultipartFormDataContent();

            content.Add(new StringContent(dto.NameFi), "NameFi");
            content.Add(new StringContent(dto.NameEn), "NameEn");
            content.Add(new StringContent(dto.DescriptionFi), "DescriptionFi");
            content.Add(new StringContent(dto.DescriptionEn), "DescriptionEn");
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
