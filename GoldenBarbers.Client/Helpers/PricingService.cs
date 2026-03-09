using Shared.DTOs;

namespace GoldenBarbers.Client.Helpers
{
    public class PricingService
    {
        public static int CalculatePrice(OfferingDto offering, int barberPositionId)
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
