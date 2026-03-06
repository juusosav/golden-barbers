using GoldenBarbers.Models.Entities;

namespace GoldenBarbers.Services
{
    public class PricingService
    {
        public int CalculatePrice(Offering offering, int barberPositionId)
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
