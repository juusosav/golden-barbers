using GoldenBarbers.Models.Entities;
using GoldenBarbers.Services.Public.Interfaces;

namespace GoldenBarbers.Services.Public
{
    public class PricingService : IPricingService
    {
        public int CalculatePrice(Offering offering, int? barberPositionId)
        {
            return barberPositionId switch
            {
                1 => offering.SeniorPrice,
                2 => offering.JuniorPrice,
                3 => offering.TraineePrice,
                _ => 0
            };
        }
    }
}
