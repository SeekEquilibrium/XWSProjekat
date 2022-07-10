using AgentApp.DTO;
using AgentApp.Models;

namespace AgentApp.Clients
{
    public class JobOfferClient
    {
        private readonly HttpClient _httpClient;

        public JobOfferClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task PostJobOffer(JobOffer offer)
        {
            await _httpClient.PostAsJsonAsync<JobOffer>($"/Offer", offer);
        }
    }
}