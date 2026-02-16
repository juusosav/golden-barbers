namespace GoldenBarbers.Client.Services
{
    public class OfferingService
    {
        private readonly HttpClient _http;

        public OfferingService(HttpClient http)
        {
            _http = http; 
        }
    }
}
