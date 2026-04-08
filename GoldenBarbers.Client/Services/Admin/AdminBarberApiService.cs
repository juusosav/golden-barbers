using Microsoft.AspNetCore.Components.Forms;
using Shared.DTOs.Admin.Barbers;
using System.Globalization;
using System.Net.Http.Json;

namespace GoldenBarbers.Client.Services.Admin
{
    public class AdminBarberApiService
    {
        private readonly HttpClient _http;

        public AdminBarberApiService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<AdminBarberDto>> GetAllBarbersAsync()
        {
            return await _http.GetFromJsonAsync<List<AdminBarberDto>>("api/admin/barbers")
                ?? new List<AdminBarberDto>();
        }

        public async Task<AdminBarberDto?> GetBarberByIdAsync(Guid id)
        {
            return await _http.GetFromJsonAsync<AdminBarberDto>($"api/admin/barbers/{id}");
        }

        public async Task<bool> DeleteBarberAsync(Guid id)
        {
            var response = await _http.DeleteAsync($"api/admin/barbers/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> EditBarberAsync(
            Guid id,
            AdminBarberDto dto,
            IBrowserFile? file)
        {
            var content = new MultipartFormDataContent();

            content.Add(new StringContent(dto.Name), "Name");
            content.Add(new StringContent(dto.DescriptionFi), "DescriptionFi");
            content.Add(new StringContent(dto.DescriptionEn), "DescriptionEn");
            content.Add(new StringContent(dto.PositionId.ToString()), "PositionId");
            content.Add(new StringContent(dto.PositionName), "PositionName");
            content.Add(new StringContent(dto.PersonalPhone), "PersonalPhone");
            content.Add(new StringContent(dto.PersonalEmail), "PersonalEmail");
            content.Add(new StringContent(dto.PersonalAddress), "PersonalAddress");
            content.Add(new StringContent(dto.Salary.ToString()), "Salary");
            content.Add(new StringContent(dto.StartDate.ToString("o", CultureInfo.InvariantCulture)), "StartDate");

            if (file != null)
            {
                var stream = file.OpenReadStream(5 * 1024 * 1024);
                var fileContent = new StreamContent(stream);
                fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(file.ContentType);

                content.Add(fileContent, "file", file.Name);
            }

            var response = await _http.PutAsync($"api/admin/barbers/{id}", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<AdminBarberDto?> CreateBarberAsync(
    AdminBarberDto dto,
    IBrowserFile? file)
        {
            var content = new MultipartFormDataContent();

            content.Add(new StringContent(dto.Name), "Name");
            content.Add(new StringContent(dto.DescriptionFi), "DescriptionFi");
            content.Add(new StringContent(dto.DescriptionEn), "DescriptionEn");
            content.Add(new StringContent(dto.PositionId.ToString()), "PositionId");
            content.Add(new StringContent(dto.PositionName), "PositionName");
            content.Add(new StringContent(dto.PersonalPhone), "PersonalPhone");
            content.Add(new StringContent(dto.PersonalEmail), "PersonalEmail");
            content.Add(new StringContent(dto.PersonalAddress), "PersonalAddress");
            content.Add(new StringContent(dto.Salary.ToString()), "Salary");
            content.Add(new StringContent(dto.StartDate.ToString("o", CultureInfo.InvariantCulture)), "StartDate");

            if (file != null)
            {
                var stream = file.OpenReadStream(5 * 1024 * 1024);
                var fileContent = new StreamContent(stream);
                fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(file.ContentType);

                content.Add(fileContent, "file", file.Name);
            }

            var response = await _http.PostAsync($"api/admin/barbers", content);

            if (!response.IsSuccessStatusCode)
                return null;

            return await response.Content.ReadFromJsonAsync<AdminBarberDto>();
        }
    }
}
