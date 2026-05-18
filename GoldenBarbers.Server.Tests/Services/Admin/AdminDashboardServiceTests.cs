using GoldenBarbers.Services.Admin;
using GoldenBarbers.Models.Entities;
using GoldenBarbers.Data;
using GoldenBarbers.Server.Tests.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenBarbers.Server.Tests.Services.Admin
{
    public class AdminDashboardServiceTests
    {
        private readonly AdminDashboardService _sut;
        private readonly ApplicationDbContext _context;

        public AdminDashboardServiceTests()
        {
            _context = ApplicationDbContextFactory.Create();
            _sut = new AdminDashboardService(_context);
        }

        [Fact]
        public async Task GetDashboardAsync_ReturnsCorrectData_WhenDataExists()
        {
            // Arrange
            var today = DateTime.UtcNow.Date;

            _context.Appointments.Add(new Appointment
            {
                Id = Guid.NewGuid(),
                AppointmentDateTime = today.AddHours(10),
                CustomerName = "Test Customer",
                BarberName = "Test Barber",
                OfferingNameFi = "Test Offering",
                FinalPrice = 50
            });

            await _context.SaveChangesAsync();

            // Act
            var result = await _sut.GetDashboardAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.AppointmentsToday);
            Assert.Equal(0, result.UpcomingWeek);
            Assert.Equal(50, result.RevenueToday);
            Assert.Single(result.TodaySchedule);
            Assert.Equal("Test Customer", result.TodaySchedule[0].CustomerName);
        }
    }
}
