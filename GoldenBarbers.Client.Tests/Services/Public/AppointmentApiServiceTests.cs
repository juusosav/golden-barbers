using GoldenBarbers.Client.Services.Public;
using RichardSzalay.MockHttp;
using Shared.DTOs.Public;
using System.Net;
using System.Net.Http.Json;

namespace GoldenBarbers.Client.Tests.Services.Public
{
    public class AppointmentApiServiceTests
    {
        private readonly MockHttpMessageHandler _mockHttp;
        private readonly AppointmentApiService _sut;

        public AppointmentApiServiceTests()
        {
            _mockHttp = new MockHttpMessageHandler();
            var httpClient = _mockHttp.ToHttpClient();
            httpClient.BaseAddress = new Uri("https://localhost");
            _sut = new AppointmentApiService(httpClient);
        }

        [Fact]
        public async Task GetAvailableSlotsAsync_ReturnsSlots_WhenSuccessful()
        {
            // Arrange
            var weekStart = new DateTime(2026, 4, 14);
            var expectedSlots = new List<TimeslotDto>
            {
                new() {
                    Id = Guid.NewGuid(),
                    BarberId = Guid.NewGuid(),
                    BarberName = "John Smith",
                    Start = weekStart.AddHours(9),
                    Duration = 30,
                    IsAvailable = true
                }
            };

            _mockHttp
                .When($"https://localhost/api/appointments/available-slots*")
                .Respond(HttpStatusCode.OK, JsonContent.Create(expectedSlots));

            // Act
            var result = await _sut.GetAvailableSlotsAsync(weekStart);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal("John Smith", result[0].BarberName);
        }

        [Fact]
        public async Task CreateAppointmentAsync_ReturnsDto_WhenSuccessful()
        {
            // Arrange
            var dto = new AppointmentDto
            {
                Id = Guid.NewGuid(),
                BarberId = Guid.NewGuid(),
                OfferingId = Guid.NewGuid(),
                CustomerName = "Jane Doe",
                CustomerEmail = "jane.doe@example.com"
            };

            _mockHttp
                .When(HttpMethod.Post, "https://localhost/api/appointments")
                .Respond(HttpStatusCode.Created, JsonContent.Create(dto));

            // Act
            var result = await _sut.CreateAppointmentAsync(dto);

            Assert.NotNull(result);
            Assert.Equal("Jane Doe", result.CustomerName);
        }

        [Fact]
        public async Task CreateAppointmentAsync_ReturnsNull_WhenFailed()
        {
            // Arrange
            _mockHttp
                .When(HttpMethod.Post, "https://localhost/api/appointments")
                .Respond(HttpStatusCode.BadRequest);

            // Act
            var result = await _sut.CreateAppointmentAsync(new AppointmentDto());

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsDto_WhenAppointmentExists()
        {
            // Arrange
            var id = Guid.NewGuid();
            var expectedDto = new AppointmentDto
            {
                Id = id,
                CustomerName = "Jane Doe"
            };

            _mockHttp
                .When($"https://localhost/api/appointments/{id}")
                .Respond(HttpStatusCode.OK, JsonContent.Create(expectedDto));

            // Act
            var result = await _sut.GetByIdAsync(id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(id, result.Id);
            Assert.Equal("Jane Doe", result.CustomerName);
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsNull_WhenAppointmentNotFound()
        {
            // Arrange
            var id = Guid.NewGuid();

            _mockHttp
                .When($"https://localhost/api/appointments/{id}")
                .Respond(HttpStatusCode.NotFound);

            // Act
            var result = await _sut.GetByIdAsync(id);

            // Assert
            Assert.Null(result);
        }
    }
}
