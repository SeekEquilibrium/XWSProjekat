using AgentApp.Models;
using Common;

namespace AgentApp.Services
{
    public class JobOfferService 
    {
        private readonly IRepository<JobOffer> _jobOfferRepository;

        public JobOfferService(IRepository<JobOffer> jobOfferRepository)
        {
            _jobOfferRepository = jobOfferRepository;
        }

        public async Task<IEnumerable<JobOffer>> GetAll()
        {
            IEnumerable<JobOffer> offers = await _jobOfferRepository.GetAllAsync();
            return offers;
        }

        public async Task CreateJobOffer(JobOffer offer)
        {
            await _jobOfferRepository.CreateAsync(offer);
        }

        public async Task<IEnumerable<JobOffer>> GetAllByCompany(String company)
        {
            IEnumerable<JobOffer> offers = await _jobOfferRepository.GetAllAsync(offer => offer.CompanyName.Equals(company));
            return offers;
        }


    }
}