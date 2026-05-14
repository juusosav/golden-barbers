using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoldenBarbers.Models.Entities;
using GoldenBarbers.Services.Public;

namespace GoldenBarbers.Server.Tests.Services.Public
{
    public class PricingServiceTests
    {
        private readonly PricingService _sut;
        private readonly Offering _offering;

        public PricingServiceTests()
        {
            _sut = new PricingService();
            _offering = new Offering
            {
                Id = Guid.NewGuid(),
                NameEn = "Barber Haircut Test",
                SeniorPrice = 100,
                JuniorPrice = 70,
                TraineePrice = 50
            };
        }

        [Fact]
        public void CalculatePrice_WithSeniorBarber_ReturnsSeniorPrice()
        {
            // Act
            var result = _sut.CalculatePrice(_offering, 1);
            // Assert
            Assert.Equal(100, result);
        }

        [Fact]
        public void CalculatePrice_WithJuniorBarber_ReturnsJuniorPrice()
        {
            // Act
            var result = _sut.CalculatePrice(_offering, 2);
            // Assert
            Assert.Equal(70, result);
        }

        [Fact]
        public void CalculatePrice_WithTraineeBarber_ReturnsTraineePrice()
        {
            // Act
            var result = _sut.CalculatePrice(_offering, 3);
            // Assert
            Assert.Equal(50, result);
        }

        [Fact]
        public void CalculatePrice_WithInvalidBarberPosition_ReturnsZero()
        {
            // Act
            var result = _sut.CalculatePrice(_offering, 999);
            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void CalculatePrice_WithNullBarberPosition_ReturnsZero()
        {
            // Act
            var result = _sut.CalculatePrice(_offering, null);
            // Assert
            Assert.Equal(0, result);
        }
    }
}
