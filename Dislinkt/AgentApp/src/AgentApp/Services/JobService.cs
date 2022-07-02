using AgentApp.Models;
using Common;

namespace AgentApp.Services
{
    public class JobService
    {
        private readonly IRepository<Job> _jobRepository;
        public JobService(IRepository<Job> jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public async Task<IEnumerable<Job>> GetAll()
        {
            IEnumerable<Job> jobs = await _jobRepository.GetAllAsync();
            return jobs;
        }

        public async Task<Job> GetJobById(Guid id)
        {
            Job job = await _jobRepository.GetAsync(job => job.Id.Equals(id));
            return job;
        }

        public async Task<IEnumerable<Job>> GetAllByCompanyId(Guid id)
        {
            IEnumerable<Job> jobs = await _jobRepository.GetAllAsync(job => job.CompanyId.Equals(id));
            return jobs;
        }

        public async Task CreateJob(Job job)
        {
            await _jobRepository.CreateAsync(job);
        }
    }
}