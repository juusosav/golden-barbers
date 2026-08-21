using GoldenBarbers.Data;
using GoldenBarbers.Services.Admin;
using GoldenBarbers.Models.Entities;
using GoldenBarbers.Server.Tests.Data;
using Shared.DTOs.Admin.Metrics;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace GoldenBarbers.Server.Tests.Services.Admin
{
    public class AdminMetricServiceTests
    {
        private readonly AdminMetricService _sut;
        private readonly ApplicationDbContext _context;

        public AdminMetricServiceTests()
        {
            _context = ApplicationDbContextFactory.Create();
            _sut = new AdminMetricService(_context);
        }

        [Fact]
        public async Task GetMetrics_ReturnsCorrectData_WhenDataExists()
        {
            //Arrange
            var today = DateTime.UtcNow.Date;

            var thisMonthStart = new DateTime(
                today.Year,
                today.Month,
                1, 0, 0, 0,
                DateTimeKind.Utc);

            var lastMonthStart = thisMonthStart.AddMonths(-1);


            _context.Appointments.AddRange(
                new Appointment
                {
                    Id = Guid.NewGuid(),
                    AppointmentDateTime = lastMonthStart.AddDays(5).AddHours(10),
                    CustomerName = "Last Month Customer",
                    BarberName = "Test Barber",
                    OfferingNameFi = "Test Offering",
                    FinalPrice = 50
                },
                new Appointment
                {
                    Id = Guid.NewGuid(),
                    AppointmentDateTime = thisMonthStart.AddDays(5).AddHours(10),
                    CustomerName = "This Month Customer 1",
                    BarberName = "Test Barber",
                    OfferingNameFi = "Test Offering",
                    FinalPrice = 50
                },
                new Appointment
                {
                    Id = Guid.NewGuid(),
                    AppointmentDateTime = thisMonthStart.AddDays(6).AddHours(10),
                    CustomerName = "This Month Customer 2",
                    BarberName = "Test Barber",
                    OfferingNameFi = "Test Offering",
                    FinalPrice = 50
                }
            );

            await _context.SaveChangesAsync();

            //Act
            var result = await _sut.GetMetricsAsync();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(100, result.AppointmentsChangeCount);
            Assert.Equal(100, result.RevenueChangeCount);
        }
    }
}
