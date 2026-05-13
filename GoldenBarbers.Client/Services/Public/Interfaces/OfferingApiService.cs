using Shared.DTOs.Public;
using System.Net.Http.Json;

namespace GoldenBarbers.Client.Services.Public
{
    public interface IOfferingApiService
    {
        Task<List<OfferingDto>> GetAllOfferingsAsync();
        Task<OfferingDto?> GetOfferingByIdAsync(Guid id);
    }
}