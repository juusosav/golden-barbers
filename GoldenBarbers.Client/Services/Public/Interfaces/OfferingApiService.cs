using Shared.DTOs.Public;

namespace GoldenBarbers.Client.Services.Public.Interfaces
{
    public interface IOfferingApiService
    {
        Task<List<OfferingDto>> GetAllOfferingsAsync();
        Task<OfferingDto?> GetOfferingByIdAsync(Guid id);
    }
}