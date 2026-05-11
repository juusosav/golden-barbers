using Shared.DTOs.Public;

namespace GoldenBarbers.Services.Public.Interfaces
{
    public interface IOfferingService
    {
        Task<IEnumerable<OfferingDto>> GetAllOfferingsAsync();
        Task<OfferingDto?> GetOfferingByIdAsync(Guid id);
    }
}
