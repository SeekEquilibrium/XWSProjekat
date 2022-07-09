using AgentApp.DTO;

namespace AgentApp.Clients
{
    public class JobOfferClient
    {
        private readonly HttpClient _httpClient;

        public JobOfferClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task PostJobOffer(JobOfferDTO offer)
        {
            await _httpClient.PostAsJsonAsync<JobOfferDTO>($"/JobOffers", offer);
        }
    }
}