using GoldenBarbers.Models.InputModels;
using GoldenBarbers.Services.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;
using Shared.DTOs.Admin.Barbers;
using System.Globalization;

namespace GoldenBarbers.Controllers.Admin
{
    [Route("api/admin/barbers")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminBarberController : ControllerBase
    {
        private readonly AdminBarberService _adminBarberService;

        public AdminBarberController(AdminBarberService adminBarberService)
        {
            _adminBarberService = adminBarberService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBarbersAsync()
        {
            var barbers = await _adminBarberService.GetAllBarbersAsync();

            if (barbers == null)
            {
                return NotFound();
            }

            return Ok(barbers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AdminBarberDto>> GetBarberByIdAsync(Guid id)
        {
            var barber = await _adminBarberService.GetBarberByIdAsync(id);

            if (barber == null)
            {
                return NotFound();
            }

            return Ok(barber);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBarberAsync(Guid id)
        {
            var deleted = await _adminBarberService.DeleteBarberAsync(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }

        [HttpPut("{id}")]
        [Consumes("multipart/form-data")]
        public async Task<ActionResult> EditBarberAsync(
            Guid id,
            [FromForm] BarberFormModel form)
        {
            if (!decimal.TryParse(form.Salary, NumberStyles.Any,
                    CultureInfo.InvariantCulture, out var salary))
                return BadRequest("Invalid salary format");

            if (!DateTime.TryParse(form.StartDate, CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out var startDate))
                return BadRequest("Invalid date format");

            var dto = new AdminBarberDto
            {
                Name = form.Name,
                PersonalEmail = form.PersonalEmail,
                PersonalPhone = form.PersonalPhone,
                PersonalAddress = form.PersonalAddress,
                PositionId = form.PositionId,
                PositionName = form.PositionName,
                Salary = salary,
                StartDate = startDate
            };

            var existing = await _adminBarberService.GetBarberByIdAsync(id);
            if (existing == null) return NotFound();

            // Handle file upload
            if (form.File != null)
            {
                if (existing != null && !string.IsNullOrEmpty(existing.Portrait))
                {
                    var oldPath = Path.Combine(
                        Directory.GetCurrentDirectory(),
                        "wwwroot",
                        existing.Portrait.TrimStart('/')
                    );

                    if (System.IO.File.Exists(oldPath))
                        System.IO.File.Delete(oldPath);
                }

                var fileName = $"{Guid.NewGuid()}_{form.File.FileName}";
                var filePath = Path.Combine("wwwroot/images", fileName);
                await using var stream = new FileStream(filePath, FileMode.Create);
                await form.File.CopyToAsync(stream);
                dto.Portrait = $"images/{fileName}";
            }
            else
            {
                dto.Portrait = existing?.Portrait ?? "";
            }

            var success = await _adminBarberService.EditBarberAsync(id, dto);
            return success ? NoContent() : BadRequest();
        }
    }
}
