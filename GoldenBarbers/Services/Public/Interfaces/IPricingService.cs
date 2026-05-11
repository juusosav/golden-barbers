using GoldenBarbers.Models.Entities;
using Shared.DTOs.Public;

namespace GoldenBarbers.Services.Public.Interfaces
{
    public interface IPricingService
    {
        int CalculatePrice(Offering offering, int? barberPositionId);
    }
}
